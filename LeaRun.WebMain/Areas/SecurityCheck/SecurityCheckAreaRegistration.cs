using System.Web.Mvc;

namespace LeaRun.SecurityCheck.Areas
{
    /// <summary>
    /// 安全排查
    /// </summary>
    public class SecurityCheckAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SecurityCheck";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
              AreaName + "_Default",
              AreaName + "/{controller}/{action}/{id}",
              new { area = AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "LeaRun." + AreaName + ".Controllers" }
            );
        }
    }
}