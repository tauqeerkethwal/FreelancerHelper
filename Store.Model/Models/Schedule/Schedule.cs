
using Freelancer.Model.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Schedule
{
    public class Schedule : UserActivityModel
    {
        [Key]
        public Guid ScheduleId { get; set; }
        public string CustomerId { get; set; }
      

        public virtual ICollection<WeekSchedule> WeekSchedules { get; set; }

        public virtual List<ScheduleEmployee> ScheduleEmployees { get; set; }

        public virtual List<DaySchedule> DaySchedules { get; set; }
        public virtual List<ScheduleWithDates> ScheduleWithDatess { get; set; }
    }
}
