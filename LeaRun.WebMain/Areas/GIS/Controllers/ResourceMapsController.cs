using LeaRun.GIS.Business;
using LeaRun.ResourceManage.Model;
using LeaRun.Util;
using LeaRun.WebBase;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;

namespace LeaRun.GIS.Controllers
{
    public class ResourceMapsController : MvcControllerBase
    {
        ResourceMapBLL resourceMapBLL = new ResourceMapBLL();

        // GET: GIS/ResourceMaps
        public ActionResult Index()
        {
            return View();
        }


        [AjaxOnly]
        public ActionResult GetResources(string queryJson) 
        {
            var queryObj = queryJson.ToJObject();

            var bounds = MapBounds.Parse(queryObj.Value<decimal?>("lngsw"), (decimal?)queryObj["latsw"], (decimal?)queryObj["lngne"], (decimal?)queryObj["latne"]);

            return ToJsonResult(resourceMapBLL.GetResources(new ResourceMapQuery() { Bounds = bounds }));
        }
    }
}