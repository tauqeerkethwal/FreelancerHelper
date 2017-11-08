using Freelancer.Model.Models.Base;
using System;
namespace Freelancer.Model.Models.Schedule
{
    public class DaysWithTime : UserActivityModel
    {
        public Guid DayWithTimeId { get; set; }

        public int Day { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }

        public Guid DayScheduleId { get; set; }
        public virtual DaySchedule DaySchedules { get; set; }
    }
}
