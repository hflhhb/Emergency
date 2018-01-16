using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutyNoteDealsMap : EntityTypeConfiguration<DutyNoteDealsEntity>
    {
        public DutyNoteDealsMap()
        {
            this.ToTable("DutyNoteDeals");
            this.HasKey(t => t.Id);
        }

    }
}
