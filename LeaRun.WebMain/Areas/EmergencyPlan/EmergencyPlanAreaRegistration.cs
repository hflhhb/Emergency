﻿using System.Web.Mvc;

namespace LeaRun.EmergencyPlan.Areas
{
    public class EmergencyPlanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EmergencyPlan";
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