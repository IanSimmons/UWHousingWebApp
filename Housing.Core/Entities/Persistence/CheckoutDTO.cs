using System;

namespace Housing.Entities.Persistence
{
    /// <summary>
    /// DTO used for studenrts being persisted
    /// </summary>
    public class CheckoutDTO
    {

        /// <summary>
        /// Equipment ID
        /// </summary>
        public int EquipmentID { get; set; }

        /// <summary>
        /// Student Name
        /// </summary>
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        /// <summary>
        /// StudentID/Building
        /// </summary>
        public long StudentID { get; set; }
        public string Buildingname { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

    }
}
