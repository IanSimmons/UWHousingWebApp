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
        public ActionResult ViewEquipment()
        {
            CheckOutEquipmentModel vm = new CheckOutEquipmentModel();
            BuildingViewer viewer = new BuildingViewer();
            vm.Building = viewer.GetAllBuildingname();
            return View(vm);
        }

        public ActionResult CheckOutEquipment(CheckOutEquipmentModel formdata)
        {
            CheckOutEquipmentModel vm = new CheckOutEquipmentModel();
            EquipmentViewer viewer = new EquipmentViewer();
            vm.Equipment = viewer.Getequipment(formdata.Buildingname);
            return View(vm);
        }

        [HttpPost]
        public ActionResult NewCheckout(CheckOutEquipmentModel formdata)
        {          
            long studentid = formdata.StudentID;
            string building = formdata.Buildingname;
            int equipmentid = formdata.EquipmentID;

            NewCheckoutDTO dto = new NewCheckoutDTO();
            dto.EquipmentID = equipmentid;
            dto.Status = "Out";
            dto.StudentID = studentid;
            
            NewCheckoutCreator checkout_Creator = new NewCheckoutCreator();
            checkout_Creator.CheckOut(dto);
            
            return RedirectToAction("AfterCheckOut", "CheckOut");
        }

        public ActionResult AfterCheckOut()
        {
            return View();
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
            dto.EquipmentID = formdata.EquipmentID;
            dto.Status = "In";
            dto.StudentID = 0;
            //?? return View(model);
            return RedirectToAction("AfterCheckIn", "CheckOut");
        }

    }
}