using System;
using System.Collections.Generic;

namespace Locations.Services.Domain
{
    /// <summary>
    /// Interface for location services
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Gets locations filtered by time
        /// </summary>
        /// <param name="from">Availability lower limit</param>
        /// <param name="to">Availability lower limit</param>
        /// <returns>Locations</returns>
        IEnumerable<ILocationDto> GetLocationsByAvailableTime(DateTime from, DateTime to);
    }
}
