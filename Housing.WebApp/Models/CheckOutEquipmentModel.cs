using Housing.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.WebApp.Models
{
    public class CheckOutEquipmentModel
    {
        public IList<BuildingViewModel> Building { get; set; }
        public IList<EquipmentViewModel> Equipment { get; set; }
        public long StudentID { get; set; }
        public int EquipmentID { get; set; }
        public string Buildingname { get; set; }


    }
}