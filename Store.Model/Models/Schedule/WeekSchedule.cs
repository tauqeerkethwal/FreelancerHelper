using Freelancer.Model.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Schedule
{
    public class WeekSchedule : UserActivityModel
    {
        [Key]
        public Guid ScheduleWeekId { get; set; }
        public int WeekType { get; set; }

        public double? hours { get; set; }

        //public string CustomerId { get; set; }
        //public string EmployeeId { get; set; }
        public Guid ScheduleId { get; set; }
        public virtual Schedule Schedules { get; set; }


       
    }
}
