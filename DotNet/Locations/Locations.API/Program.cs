using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


/// <summary>
/// 
/// </summary>
/// <value></value>
app.MapGet("/locations", (int? from, int? to) =>
{
    try
        {
            var result = new List<int> {1 ,2};
            return result.Any() ?
                Results.Ok(result) :
                Results.NotFound(result);
        }
        catch (System.Exception ex)
        {
            app.Logger.LogError(new EventId(), ex, message: null);
            return Results.Problem("There was a problem with your request");
        }
}).WithName("GetLocations");

app.Run();
