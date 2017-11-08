using Freelancer.Model.Models.Schedule;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class DaysWithTimeConfiguration : EntityTypeConfiguration<DaysWithTime>
    {
        public DaysWithTimeConfiguration()
        {
            ToTable("DaysWithTime");
            HasKey(c => c.DayWithTimeId);


            HasRequired(c => c.DaySchedules).WithMany(s => s.DaysWithTimes).HasForeignKey(c => c.DayScheduleId);
        }
    }
}
