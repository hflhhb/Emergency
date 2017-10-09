using LeaRun.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.EmergencyDuty.Helper
{
    public static class Helper
    {
        public static Dictionary<DutyTypeEnum, string> MapToDutyTypes(DutyClassEnum? dutyClass)
        {
            var dict = new Dictionary<DutyTypeEnum, string>();
            switch (dutyClass)
            {
                case DutyClassEnum.Month:
                    dict.Add(DutyTypeEnum.Leader, "值班领导");
                    dict.Add(DutyTypeEnum.Daytime, "值班人员（白班）");
                    dict.Add(DutyTypeEnum.Night, "值班人员（夜班）");
                    break;
                case DutyClassEnum.Noon:
                    dict.Add(DutyTypeEnum.Noon, "值班人员");
                    break;
                case DutyClassEnum.Flexible:
                    dict.Add(DutyTypeEnum.Holiday, "机动值班人员");
                    break;
                case DutyClassEnum.Driver:
                    dict.Add(DutyTypeEnum.Daytime, "值班人员（日班）");
                    dict.Add(DutyTypeEnum.DayBackup, "值班人员（日备）");
                    dict.Add(DutyTypeEnum.Night, "值班人员（夜班）");
                    break;
                case DutyClassEnum.HolidayLeader:
                    dict.Add(DutyTypeEnum.Leader, "值班领导");
                    break;
                default:
                    dict.Add(DutyTypeEnum.Abnormal, "值班人员");
                    break;
            }

            return dict;
        }
    }
}
