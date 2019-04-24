using System;
using System.Collections.Generic;
using System.Text;

namespace UWHousing.Entities.DTO
{
    /// <summary>
    /// DTO for transferring new package info from presentation layer
    /// </summary>
    public class NewCheckoutDTO
    {
        public NewCheckoutDTO()
        {

        }

        /// <summary>
        /// Tracking Number
        /// </summary>
        public long Trackingnum { get; set; }

        /// <summary>
        /// Student Name
        /// </summary>
        public string Firstname { get; set; }
        public string Lastname { get; set; }


    }
}