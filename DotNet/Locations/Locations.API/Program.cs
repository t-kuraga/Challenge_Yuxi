using Locations.Services;
using Locations.Services.Domain;
using Locations.Repositories.Domain;
using Locations.Repositories.CsvFile;

var builder = WebApplication.CreateBuilder(args);

// Create a repository singleton
var storesPath = Path.GetFullPath("./src/Stores.csv");
builder.Services.AddSingleton<ILocationRepository>(new CsvLocationRepository(storesPath));

builder.Services.AddTransient<ILocationService, LocationService>();
var app = builder.Build();

/// <summary>
/// Locations GET endpoint
/// </summary>
/// <value>Found locations</value>
app.MapGet("/locations/available", (int? from, int? to,
    ILocationService locationService) =>
{
    try
    {
        // Parse dates to default values
        var fromDateSuccess = DateTime.TryParse($"{from ?? 10}:00", out var fromDate);
        var toDateSuccess = DateTime.TryParse($"{to ?? 13}:00", out var toDate);

        // Get available locations
        var result = locationService.GetLocationsByAvailableTime(
            fromDateSuccess ? fromDate : DateTime.Parse("10:00"),
            toDateSuccess ? toDate : DateTime.Parse("13:00"));

        // Return an http result
        return result.Any() ?
            Results.Ok(result) :
            Results.NotFound(result);
    }
    catch (System.Exception ex)
    {
        app.Logger.LogError(new EventId(), ex, message: ex.Message);
        return Results.Problem("There was a problem with your request");
    }
}).WithName("GetLocationsByAvailableTime");

app.Run();
