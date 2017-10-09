using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutyDetailsMap : EntityTypeConfiguration<DutyDetailsEntity>
    {
        public DutyDetailsMap()
        {
            this.ToTable("DutyDetails");
            this.HasKey(t => t.Id);
        }

    }
}
