using Housing.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.WebApp.Models
{
    public class CreateStudentModel
    {
        public long StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public BuildingViewModel Building { get; set; }

    }
}