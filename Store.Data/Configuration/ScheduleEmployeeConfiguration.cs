using Freelancer.Model.Models.Schedule;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class ScheduleEmployeeConfiguration : EntityTypeConfiguration<ScheduleEmployee>
    {
        public ScheduleEmployeeConfiguration()
        {
            ToTable("ScheduleEmployee");
            HasKey(c => c.ScheduleEmployeeId);
          
           
            HasRequired(c => c.Schedules).WithMany(s => s.ScheduleEmployees).HasForeignKey(c => c.ScheduleId);

        }
    }
}
