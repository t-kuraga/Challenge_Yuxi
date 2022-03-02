using System.Globalization;
using System.Net;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Locations.Services.Domain;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Locations.Services.Dto;

namespace Locations.Tests.Tests.API;

public class LocationsAPITests
{
    [Fact]
    public async Task GetLocationsByAvailableTime_Ok()
    {
        // Arrange
        bool serviceCalled = false;
        DateTime? from = null, to = null;
        var mockLocationService = new Mock<ILocationService>();
        mockLocationService.Setup(s => s.GetLocationsByAvailableTime(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns(new List<ILocationDto>
            {
                new LocationDto(0, "Fake Location 1", "Fake Address 1", 
                    DateTime.ParseExact("10:00", "HH:mm", CultureInfo.InvariantCulture), 
                    DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture))
            })
            .Callback<DateTime, DateTime>((f, t) => {
                serviceCalled = true;
                to = t;
                from = f;
            });

        using var client = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.Replace(ServiceDescriptor.Transient(_ => mockLocationService.Object));
            });
        }).CreateClient();

        // Act
        var response = await client.GetAsync($"/locations/available?from=10&to=13")
            .ConfigureAwait(false);

        // Assert
        Assert.True(serviceCalled);
        Assert.Equal(DateTime.ParseExact("10:00", "HH:mm", CultureInfo.InvariantCulture), from);
        Assert.Equal(DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture), to);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Assert.Contains("Fake Location 1", result);
    }

    [Fact]
    public async Task GetLocationsByAvailableTime_NoContent()
    {
        // Arrange
        var mockLocationService = new Mock<ILocationService>();
        mockLocationService.Setup(s => s.GetLocationsByAvailableTime(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns(new List<ILocationDto>
            {
            });

        using var client = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.Replace(ServiceDescriptor.Transient(_ => mockLocationService.Object));
            });
        }).CreateClient();

        // Act
        var response = await client.GetAsync($"/locations/available?from=10&to=13")
            .ConfigureAwait(false);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetLocationsByAvailableTime_Error()
    {
        // Arrange
        var mockLocationService = new Mock<ILocationService>();
        mockLocationService.Setup(s => s.GetLocationsByAvailableTime(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Throws(new Exception("Fake Exception"));

        using var client = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.Replace(ServiceDescriptor.Transient(_ => mockLocationService.Object));
            });
        }).CreateClient();

        // Act
        var response = await client.GetAsync($"/locations/available?from=10&to=13")
            .ConfigureAwait(false);

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}