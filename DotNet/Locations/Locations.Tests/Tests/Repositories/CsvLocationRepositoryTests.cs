using System;
using System.Collections.Generic;
using System.Linq;
using Locations.Repositories.CsvFile;
using Locations.Repositories.CsvFile.Dto;
using Locations.Repositories.Domain;
using Xunit;

namespace Locations.Tests.Tests.Repositories;

public class CsvLocationRepositoryTests
{
    [Fact]
    public void GetLocations_Ok()
    {
        // Arrange
        var repository = new CsvLocationRepository(new List<ILocationDto> {
            new LocationDto { Id = 1, City = "Fake City 1", Name = "Fake Name 1", Address = "Fake Address 1"},
            new LocationDto { Id = 2, City = "Fake City 2", Name = "Fake Name 2", Address = "Fake Address 2"}
        });

        // Act
        var result = repository.GetLocations();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetLocations_WithPredicate_Ok()
    {
        // Arrange
        var repository = new CsvLocationRepository(new List<ILocationDto> {
            new LocationDto { Id = 1, City = "Fake City 1", Name = "Fake Name 1", Address = "Fake Address 1"},
            new LocationDto { Id = 2, City = "Fake City 2", Name = "Fake Name 2", Address = "Fake Address 2"}
        });

        // Act
        var result = repository.GetLocations(l => l.Id == 1);

        // Assert
        Assert.Equal(1, result.Count());
        Assert.Equal("Fake City 1", result.First().City);
    }

}