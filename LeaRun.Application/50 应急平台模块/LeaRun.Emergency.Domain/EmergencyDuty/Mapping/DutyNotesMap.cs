using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutyNotesMap : EntityTypeConfiguration<DutyNotesEntity>
    {
        public DutyNotesMap()
        {
            this.ToTable("DutyNotes");
            this.HasKey(t => t.Id);
        }

    }
}
