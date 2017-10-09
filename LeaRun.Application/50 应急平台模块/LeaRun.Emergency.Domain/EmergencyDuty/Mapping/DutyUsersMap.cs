using System;
using System.Data.Entity.ModelConfiguration;
using LeaRun.EmergencyDuty.Entity;

namespace LeaRun.EmergencyDuty.Mapping
{
    public class DutyUsersMap : EntityTypeConfiguration<DutyUsersEntity>
    {
        public DutyUsersMap()
        {
            this.ToTable("DutyUsers");
            this.HasKey(t => t.Id);
        }

    }
}
