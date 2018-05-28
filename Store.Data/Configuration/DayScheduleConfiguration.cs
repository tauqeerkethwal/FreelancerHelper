using Freelancer.Model.Models.Schedule;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class DayScheduleConfiguration : EntityTypeConfiguration<DaySchedule>
    {
        public DayScheduleConfiguration()
        {
            ToTable("DaySchedule");
            Property(c => c.DayScheduleId).IsRequired();
            HasRequired(c => c.Schedules).WithMany(s => s.DaySchedules).HasForeignKey(c => c.ScheduleId);
        }
    }
}
