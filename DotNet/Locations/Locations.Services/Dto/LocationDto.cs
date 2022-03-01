using System;
using Locations.Services.Domain;

namespace Locations.Services.Dto
{
    /// <summary>
    /// Interface for location dtos
    /// </summary>
    /// <param name="Id">Location id</param>
    /// <param name="Name">Name</param>
    /// <param name="Address">Address</param>
    /// <param name="OpenFrom">Time of oppening</param>
    /// <param name="OpenTo">Time of closing</param>
    public record LocationDto(int Id, string Name, string Address, DateTime OpenFrom, DateTime OpenTo) : ILocationDto;
}

