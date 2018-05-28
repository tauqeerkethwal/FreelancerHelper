using Freelancer.Model.Models.Schedule;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class WeekScheduleConfiguration : EntityTypeConfiguration<WeekSchedule>
    {
        public WeekScheduleConfiguration()
        {
            ToTable("WeekSchedule");

    
   
            HasKey(c => c.ScheduleWeekId);
           /* HasRequired(c => c.Schedules).WithMany(s => s.WeekSchedules).HasForeignKey(c => c.ScheduleId); */            ;
        
         
        }
    }
}
