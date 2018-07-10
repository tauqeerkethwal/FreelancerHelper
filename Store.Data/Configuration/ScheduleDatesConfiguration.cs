using Freelancer.Model.Models.Schedule;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class ScheduleDatesConfiguration : EntityTypeConfiguration<ScheduleWithDates>
    {
        public ScheduleDatesConfiguration()
        {
            ToTable("ScheduleDates");



            HasKey(c => c.ScheduleWithDatesId);
            /* HasRequired(c => c.Schedules).WithMany(s => s.WeekSchedules).HasForeignKey(c => c.ScheduleId); */
            ;


        }
    }
}