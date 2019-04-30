using Housing.BLL;
using Housing.Entities.Persistence;
using Housing.Entities.ViewModels;
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
    public class PackagesController : Controller
    {
        public ActionResult LogPackage()
        {
            LogPackageModel vm = new LogPackageModel();
            BuildingViewer viewer = new BuildingViewer();
            vm.Building = viewer.GetAllBuildingname();
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreatePackage(LogPackageModel formdata)
        {
            NewPackageDTO dto = new NewPackageDTO();

            dto.TrackingID = formdata.TrackingIDber;
            dto.Firstname = formdata.FirstName;
            dto.Lastname = formdata.LastName;
            dto.Logtime = DateTime.Now;
            dto.Buildingname = formdata.BuildingName;

            NewPackageCreator package_Creator = new NewPackageCreator();
            package_Creator.CreatePackage(dto);

            return RedirectToAction("AfterPackageLog", "Package");
        }

        public ActionResult AfterPackageLog()
        {
            return View();
        }

        public ActionResult ViewPackages()
        {
            return View();
        }

        public ActionResult ReleasePackage(LogPackageModel formdata)
        {
            ReleasePackageModel vm = new ReleasePackageModel();
            PackageViewer viewer = new PackageViewer();
            vm.Packages = viewer.GetPackage(formdata.FirstName, formdata.LastName);
            return View(vm);
        }

        [HttpPost]
        public ActionResult NewReleasePackage(ReleasePackageModel formdata)
        {
            //string firstname = formdata.FirstName;
            //string lastname = formdata.LastName;
            
            //var model = new ReleasePackageModel();
            //model.Packages = packages;
            //model.FirstName = firstname;
            //model.LastName = lastname;

            NewPackageDTO dto = new NewPackageDTO();
            dto.TrackingID = formdata.TrackingID;
            dto.Releasetime = DateTime.Now;


            PackageReleaser package_Releaser = new PackageReleaser();
            package_Releaser.ReleasePackage(dto);

            return RedirectToAction("AfterPackageRelease", "Package");
        }

        //public ActionResult 

    }
}