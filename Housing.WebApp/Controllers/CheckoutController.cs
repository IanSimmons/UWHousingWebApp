using Housing.BLL;
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
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOutEquipment(CheckOutEquipmentModel formdata)
        {
            

            long studentid = formdata.StudentID;
            string building = formdata.Building.Buildingname;

            EquipmentViewer equipment_viewer = new EquipmentViewer();
            IList<EquipmentViewModel> equipment = equipment_viewer.Getequipment(building);

            NewCheckoutDTO dto = new NewCheckoutDTO();
            dto.EquipmentID = formdata.EquipmentID;
            dto.Status = "Out";
            dto.StudentID = studentid;
            
            NewCheckoutCreator package_Creator = new NewCheckoutCreator(); //??
            package_Creator.CreatePackage(dto);

            return RedirectToAction("AfterCheckOut", "CheckOut");
        }

        [HttpPost]
        public ActionResult CheckInEquipment(CheckInEquipmentModel formdata)
        {
            //?? display buildings

            long studentid = formdata.StudentID;
            string building = formdata.Building.Buildingname;

            EquipmentViewer equipment_viewer = new EquipmentViewer();
            IList<EquipmentViewModel> equipment = equipment_viewer.GetequipmentByStudent(studentid);

            var model = new CheckInEquipmentModel();
            model.StudentID = studentid;
            model.Equipment = equipment;

            NewCheckoutDTO dto = new NewCheckoutDTO();
            dto.EquipmentID = formdata.Equipment;
            dto.Status = "In";
            dto.StudentID = 0;
            //?? return View(model);
            return RedirectToAction("AfterCheckIn", "CheckOut");
        }

    }
}