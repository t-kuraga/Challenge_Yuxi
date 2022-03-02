using System;
using System.Collections.Generic;
using System.Linq;
using Locations.Repositories.Domain;
using Locations.Services;
using Moq;
using Xunit;
using RepositoryDomain = Locations.Repositories.Domain;

namespace Locations.Tests.Tests.Services;

public class LocationServiceTests
{
    #region Fake Classes
    private class FakeLocationDto : RepositoryDomain.ILocationDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime OpenFrom { get; set; }

        public DateTime OpenTo { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
    #endregion

    [Theory]
    [InlineData(10, 13, 10, 13, true)]
    public void GetLocationsByAvailableTime_Ok(int from, int to, int expectedFrom, int expectedTo, bool expectedResult)
    {
        // Arrange
        var predicateResult = false;
        DateTime.TryParse($"{expectedFrom}:00", out var fromExpectedDate);
        DateTime.TryParse($"{expectedTo}:00", out var toExpectedDate);
        DateTime.TryParse($"{from}:00", out var fromDate);
        DateTime.TryParse($"{to}:00", out var toDate);

        var predicateParameter = new FakeLocationDto
        {
            Id = 1,
            OpenFrom = fromExpectedDate,
            OpenTo = toExpectedDate
        };
        var repositoryMock = new Mock<ILocationRepository>();
        repositoryMock.Setup(m => m.GetLocations(It.IsAny<Func<ILocationDto, bool>>()))
            .Returns(new List<RepositoryDomain.ILocationDto> {
                new FakeLocationDto { Id = 1, City = "Fake City 1", Name = "Fake Name 1", Address = "Fake Address 1" },
                new FakeLocationDto { Id = 2, City = "Fake City 2", Name = "Fake Name 2", Address = "Fake Address 2" }
            })
            .Callback<Func<ILocationDto, bool>>(f => predicateResult = f(predicateParameter));
        var service = new LocationService(repositoryMock.Object);

        // Act
        var result = service.GetLocationsByAvailableTime(fromDate, toDate);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(expectedResult, predicateResult);
    }
}