using Housing.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.WebApp.Models
{
    public class LogPackageModel
    {
        public long TrackingIDber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BuildingName { get; set; }

        public IList<BuildingViewModel> Building { get; set; }
    }
}