using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuvenileSportsManagementApp.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Portal()
        {
            return View();
        }

        //GET: Success
        public ViewResult Success()
        {
            return View();
        }

        //GET: Fail
        public ViewResult Fail()
        {
            return View();
        }
    }
}