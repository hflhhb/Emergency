using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class EmergencyReportsMap : EntityTypeConfiguration<EmergencyReportsEntity>
    {
        public EmergencyReportsMap()
        {
            this.ToTable("EmergencyReports");
            this.HasKey(t => t.Id);
        }

    }
}
