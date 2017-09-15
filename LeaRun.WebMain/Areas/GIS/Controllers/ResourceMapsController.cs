using LeaRun.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.GIS.Controllers
{
    public class ResourceMapsController : MvcControllerBase
    {
        // GET: GIS/ResourceMaps
        public ActionResult Index()
        {
            return View();
        }
    }
}