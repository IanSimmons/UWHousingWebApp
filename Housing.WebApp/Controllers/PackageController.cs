using Housing.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using UWHousing.Entities.DTO;

namespace Housing.WebApp.Controllers
{
    public class PackageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogPackage(LogPackageModel formdata)
        {
            NewCheckoutDTO dto = new NewCheckoutDTO();

            dto.Trackingnum = formdata.TrackingNumber;
            dto.Firstname = formdata.FirstName;
            dto.Lastname = formdata.LastName;
            dto.Logtime = DateTime.Now;

            NewPackageCreator package_Creator = new NewPackageCreator();
            package_Creator.CreatePackage(dto);

            return RedirectToAction("AfterPackageLog", "Package");
        }

        [HttpPost]
        public ActionResult ReleasePackage(ReleasePackageModel formdata)
        {

            //TODO - set release time


            return RedirectToAction("AfterPackageRelease", "Package");
        }

    }
}