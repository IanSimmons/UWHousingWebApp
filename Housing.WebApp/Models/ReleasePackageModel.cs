﻿using Housing.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.WebApp.Models
{
    public class ReleasePackageModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TrackingID { get; set; }
        public IList<PackageViewModel> Packages { get; set; }
    }
}