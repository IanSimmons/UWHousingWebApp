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
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOutEquipment(CheckOutEquipmentModel formdata)
        {
            NewCheckoutDTO dto = new NewCheckoutDTO();

            dto.StudentID = formdata.StudentID;
            //TODO set status to checked out

            NewPackageCreator package_Creator = new NewCheckoutCreator();
            package_Creator.CreatePackage(dto);

            return RedirectToAction("AfterPackageLog", "Package");
        }

        [HttpPost]
        public ActionResult ReleasePackage(ReleasePackageModel formdata)
        {

            //TODO

            return RedirectToAction("AfterPackageRelease", "Package");
        }

    }
}