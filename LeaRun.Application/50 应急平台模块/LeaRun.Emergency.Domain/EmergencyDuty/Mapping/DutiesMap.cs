using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutiesMap : EntityTypeConfiguration<DutiesEntity>
    {
        public DutiesMap()
        {
            this.ToTable("Duties");
            this.HasKey(t => t.Id);
        }

    }
}
