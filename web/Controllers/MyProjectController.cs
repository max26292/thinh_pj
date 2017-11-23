using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class MyProjectController : Controller
    {
        // GET: MyProject
        public ActionResult Index()
        {
            return View("Home");

        }
        public ActionResult boncho()
        {
            return View();

        }
        public ActionResult baycho()
        {
            return View();

        }
        public ActionResult muoisaucho()
        {
            return View();

        }
        public ActionResult haichincho()
        {
            return View();

        }
        public ActionResult nammuoicho()
        {
            return View();

        }
        public ActionResult news()
        {
            return View();

        }
    }
}