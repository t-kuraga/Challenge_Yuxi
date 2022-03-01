using System;

namespace Locations.Services.Domain
{
    /// <summary>
    /// Interface for location dtos
    /// </summary>
    public interface ILocationDto
    {
        /// <summary>
        /// Location id
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Time of oppening
        /// </summary>
        public DateTime OpenFrom { get; }
        /// <summary>
        /// Time of closing
        /// </summary>
        /// <value></value>
        public DateTime OpenTo { get; }

    }
}
