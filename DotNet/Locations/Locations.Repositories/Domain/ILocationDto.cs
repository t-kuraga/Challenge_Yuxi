using System;

namespace Locations.Repositories.Domain
{
    /// <summary>
    /// Interface for repository locations
    /// </summary>
    public interface ILocationDto
    {
        /// <summary>
        /// Location id
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Address
        /// </summary>
        string Address { get; }
        /// <summary>
        /// City
        /// </summary>
        string City { get; }
        /// <summary>
        /// Openning time
        /// </summary>
        DateTime OpenFrom { get; }
        /// <summary>
        /// Clossing time
        /// </summary>
        DateTime OpenTo { get; }
        /// <summary>
        /// Latitude
        /// </summary>
        double Latitude { get; }
        /// <summary>
        /// Longitude
        /// </summary>
        double Longitude { get; }
    }
}
