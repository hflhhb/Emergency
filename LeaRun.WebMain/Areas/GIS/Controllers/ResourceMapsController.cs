using LeaRun.GIS.Business;
using LeaRun.ResourceManage.Model;
using LeaRun.Util;
using LeaRun.WebBase;
using Newtonsoft.Json.Linq;
using System.Collections;
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
            var objBounds = queryObj["bounds"];
            var aryKinds = (JArray)queryObj?.SelectToken("kinds");

            var bounds = MapBounds.Parse(
                objBounds?.Value<decimal?>("lngsw"), objBounds?.Value<decimal?>("latsw"),
                objBounds?.Value<decimal?>("lngne"), objBounds?.Value<decimal?>("latne"));

            return ToJsonResult(resourceMapBLL.GetResources(aryKinds?.ToObject<string[]>(), 
                new ResourceMapQuery() { Bounds = bounds, Address = queryObj?.Value<string>("address") }));
        }
    }
}