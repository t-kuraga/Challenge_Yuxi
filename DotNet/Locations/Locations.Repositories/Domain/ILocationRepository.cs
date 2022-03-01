using System;
using System.Collections.Generic;

namespace Locations.Repositories.Domain
{
    /// <summary>
    /// Interface for location repositories
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>Locaions</returns>
        IEnumerable<ILocationDto> GetLocations();

        /// <summary>
        /// Get all locations that comply with a predicate
        /// </summary>
        /// <param name="predicate">Condition predicate</param>
        /// <returns>Locations</returns>
        IEnumerable<ILocationDto> GetLocations(Func<ILocationDto, bool> predicate);
    }
}
