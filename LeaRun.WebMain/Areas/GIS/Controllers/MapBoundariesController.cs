using LeaRun.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.GIS.Controllers
{
    public class MapBoundariesController : MvcControllerBase
    {
        // GET: GIS/MapBoundaries
        public ActionResult Index()
        {
            return View();
        }

        // GET: GIS/MapBoundaries/Design
        public ActionResult Design()
        {
            return View();
        }
    }
}