using System;
using System.Collections.Generic;
using System.Linq;
using Locations.Repositories.Domain;
using Locations.Services.Domain;
using Locations.Services.Dto;

namespace Locations.Services
{
    public class LocationService : ILocationService
    {
        /// <summary>
        /// Location repository
        /// </summary>
        private ILocationRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Location repository</param>
        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets locations filtered by time
        /// </summary>
        /// <param name="from">Availability lower limit</param>
        /// <param name="to">Availability lower limit</param>
        /// <returns>Locations</returns>
        public IEnumerable<Locations.Services.Domain.ILocationDto> GetLocationsByAvailableTime(DateTime from, DateTime to) =>
            // Get locations that are open between the selected range
            _repository.GetLocations(l => l.OpenFrom <= from && l.OpenTo <= to)
            .Select(l => new LocationDto(l.Id, l.Name, l.Address, l.OpenFrom, l.OpenTo));
    }
}
