using System;
using System.Collections.Generic;
using Locations.Repositories.Domain;

namespace Locations.Repositories.CsvFile
{
    /// <summary>
    /// Csv locations repository
    /// </summary>
    public class CsvLocationRepository : ILocationRepository
    {
        /// <summary>
        /// File path
        /// </summary>
        private string _filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fullFilePath">Full file path</param>
        public CsvLocationRepository(string fullFilePath)
        {
            _filePath = fullFilePath;
        }

        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>Locaions</returns>
        public IEnumerable<ILocationDto> GetLocations()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all locations that comply with a predicate
        /// </summary>
        /// <param name="predicate">Condition predicate</param>
        /// <returns>Locations</returns>
        public IEnumerable<ILocationDto> GetLocations(Func<ILocationDto, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}