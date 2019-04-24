using Housing.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.WebApp.Models
{
    public class ReleasePackageModel
    {
        public IList<PackageViewModel> Package { get; set; }

    }
}