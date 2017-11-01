using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutyNoteOrdersMap : EntityTypeConfiguration<DutyNoteOrdersEntity>
    {
        public DutyNoteOrdersMap()
        {
            this.ToTable("DutyNoteOrders");
            this.HasKey(t => t.Id);
        }

    }
}
