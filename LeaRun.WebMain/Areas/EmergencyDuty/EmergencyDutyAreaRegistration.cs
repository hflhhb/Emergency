﻿using System.Web.Mvc;

namespace LeaRun.EmergencyDuty.Areas
{
    /// <summary>
    /// 应急值守
    /// </summary>
    public class EmergencyDutyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EmergencyDuty";
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