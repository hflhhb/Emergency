using LeaRun.EmergencyDuty.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class EmergencyReportsEntity
    {
        [NotMapped]
        public string EvtClassDesc { get; set; }
        [NotMapped]
        public string EvtSubClassDesc { get; set; }
        [NotMapped]
        public string EvtAreaName { get; set; }
        [NotMapped]
        public string SendDeptName { get; set; }
    }
}
