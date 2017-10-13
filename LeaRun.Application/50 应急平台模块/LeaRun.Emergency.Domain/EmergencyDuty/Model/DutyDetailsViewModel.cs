using LeaRun.Definitions.Enums;
using LeaRun.EmergencyDuty.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.EmergencyDuty.Model
{
    public class DutyDetailsViewModel
    {
        public string DutyId { get; set; }

        public DateTime DutyMonth { get; set; }

        public DutyClassEnum? DutyClass { get; set; }

        public List<DutyDetailsEntity> Details { get; set; }

        public bool Readonly { get; set; }

        public DutyDetailsViewModel()
        {
            
        }

    }
}
