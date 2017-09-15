using LeaRun.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.GIS.Controllers
{
    public class GeoLocationsController : MvcControllerBase
    {
        // GET: GIS/GeoLocations
        public ActionResult Index()
        {
            return View();
        }
    }
}