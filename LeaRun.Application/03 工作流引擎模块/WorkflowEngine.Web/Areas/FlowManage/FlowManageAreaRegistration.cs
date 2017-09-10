using System.Web.Mvc;

namespace LeaRun.FlowManage.Areas
{
    public class FlowManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FlowManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "LeaRun." + this.AreaName + ".Controllers" }
            );
        }
    }
}
