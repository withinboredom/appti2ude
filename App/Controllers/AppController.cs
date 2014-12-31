using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            var model = Mocks.getDashMock();

            return View(model);
        }

        public ActionResult AddVehicle()
        {
            return View();
        }

        public ActionResult Fillup(string id)
        {
            var model = Mocks.getFillupMock();
            return View(model);
        }

        public ActionResult Maintain(string id)
        {
            return View();
        }

        public ActionResult Trip(string id)
        {
            return View();
        }
    }
}