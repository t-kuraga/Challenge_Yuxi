using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Locations.Repositories.CsvFile.Dto;
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
        /// Loaded data from file
        /// </summary>
        private readonly IEnumerable<ILocationDto> _data;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fullFilePath">Full file path</param>
        public CsvLocationRepository(string fullFilePath)
        {
            _filePath = fullFilePath;

            // Get records from csv helper
            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                _data = csv.GetRecords<LocationDto>().ToList();
            }

        }

        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>Locaions</returns>
        public IEnumerable<ILocationDto> GetLocations() => _data;

        /// <summary>
        /// Get all locations that comply with a predicate
        /// </summary>
        /// <param name="predicate">Condition predicate</param>
        /// <returns>Locations</returns>
        public IEnumerable<ILocationDto> GetLocations(Func<ILocationDto, bool> predicate) =>
            _data.Where(predicate);
    }
}