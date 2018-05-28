using Freelancer.Model.Models.Schedule;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class ScheduleConfiguration : EntityTypeConfiguration<Schedule>
    {
        public ScheduleConfiguration()
        {
            ToTable("Schedule");
            HasKey(c => c.ScheduleId);
            Property(c => c.ScheduleId).IsRequired();
            
        }
    }
}
