using Locations.Services;
using Locations.Services.Domain;
using Locations.Repositories.Domain;
using Locations.Repositories.CsvFile;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ILocationRepository>(new CsvLocationRepository("./src/Stores.csv"));
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
        //var result = locationService.GetLocationsByAvailableTime(from,to);
        var result = new List<int> { 1, 2 };
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
