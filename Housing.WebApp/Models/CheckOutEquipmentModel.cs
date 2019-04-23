using Housing.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.WebApp.Models
{
    public class CheckOutEquipmentModel
    {
        public BuildingViewModel Building { get; set; }
        public IList<EquipmentViewModel> Equipment { get; set; }
        public long StudentID { get; set; }


    }
}