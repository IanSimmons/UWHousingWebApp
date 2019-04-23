using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Housing.WebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        //View for creating new orders
        public ActionResult NewStudent()
        {

          

            return View();
        }

        public ActionResult CreateStudent()
        {
           
    
            return RedirectToAction("AfterStudent", "Student");

        }
    }
}