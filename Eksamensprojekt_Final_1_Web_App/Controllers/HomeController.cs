using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Eksamensprojekt_Final_1_Web_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext databaseContext = new DatabaseContext();

            ViewBag.data = databaseContext.Messages;

            return View();
        }
    }
}