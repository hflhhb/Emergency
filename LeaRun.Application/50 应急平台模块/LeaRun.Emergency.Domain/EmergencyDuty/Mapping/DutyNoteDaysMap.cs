using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutyNoteDaysMap : EntityTypeConfiguration<DutyNoteDaysEntity>
    {
        public DutyNoteDaysMap()
        {
            this.ToTable("DutyNoteDays");
            this.HasKey(t => t.Id);
        }

    }
}
