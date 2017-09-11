using LeaRun.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebMain.Areas.GIS
{
    public class EmergencyController : MvcControllerBase
    {
        // GET: GIS/Emergency
        public ActionResult Index()
        {
            return View();
        }
    }
}