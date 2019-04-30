using Housing.BLL;
using Housing.Entities.DTO;
using Housing.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Housing.WebApp.Controllers
{
    public class StudentController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(CreateStudentModel formdata)
        {
            NewStudentDTO dto = new NewStudentDTO();

            dto.StudentID = formdata.StudentID;
            dto.Firstname = formdata.FirstName;
            dto.Lastname = formdata.LastName;
            dto.Address = formdata.Address;
            dto.Buildingname = formdata.Building.Buildingname;

            NewStudentCreator student_Creator = new NewStudentCreator();
            student_Creator.CreateStudent(dto);
    
            return RedirectToAction("AfterStudent", "Student");

        }

        public ActionResult ViewStudent(long studentid)
        {
            StudentViewer student_viewer = new StudentViewer();

            var model = new ViewStudentModel();
            //TODO

            return View(model);
        }
    }
}