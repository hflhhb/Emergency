using AutoMapper;
using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaRun.WebMain.Infrastructure
{
    public class MapperInitialize
    {
        public static void Initialize()
        {
            Mapper.Initialize(c => {
                //c.CreateMap<EmergencyReportsEntity, EmergencyReportsViewModel>();
            });
        }
    }
}