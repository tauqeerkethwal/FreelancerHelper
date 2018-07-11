using Freelancer.Model.Models.Schedule;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class ScheduleDatesConfiguration : EntityTypeConfiguration<ScheduleWithDates>
    {
        public ScheduleDatesConfiguration()
        {
            ToTable("ScheduleWithDates");
            HasKey(c => c.ScheduleWithDatesId);
            HasRequired(c => c.Schedules).WithMany(s => s.ScheduleWithDatess).HasForeignKey(c => c.ScheduleId);
            ;


        }
    }
}