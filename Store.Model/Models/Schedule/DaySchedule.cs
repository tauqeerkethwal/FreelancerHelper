using Freelancer.Model.Models.Base;
using System;
using System.Collections.Generic;
namespace Freelancer.Model.Models.Schedule
{
    public class DaySchedule : UserActivityModel
    {
        public Guid DayScheduleId { get; set; }

        public int Type { get; set; }

       
        public Guid ScheduleId { get; set; }
        public virtual Schedule Schedules { get; set; }

        public virtual List<DaysWithTime> DaysWithTimes { get; set; }
    }
}
