using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutyNoteReportsMap : EntityTypeConfiguration<DutyNoteReportsEntity>
    {
        public DutyNoteReportsMap()
        {
            this.ToTable("DutyNoteReports");
            this.HasKey(t => t.Id);
        }

    }
}
