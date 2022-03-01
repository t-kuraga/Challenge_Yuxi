using System;
using CsvHelper.Configuration.Attributes;
using Locations.Repositories.Domain;

namespace Locations.Repositories.CsvFile.Dto
{
    public class LocationDto : ILocationDto
    {
        [Name("id")]
        public int Id { get; set; }

        [Name("name")]
        public string Name { get; set; }

        [Name("address")]
        public string Address { get; set; }

        [Name("city")]
        public string City { get; set; }

        [Name("openfrom")]
        public DateTime OpenFrom { get; set; }

        [Name("opento")]
        public DateTime OpenTo { get; set; }

        [Name("latitude")]
        public double Latitude { get; set; }

        [Name("longitude")]
        public double Longitude {get; set; }
    }
}