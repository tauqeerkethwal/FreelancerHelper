using Freelancer.Model.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Freelancer.Model.Models.Schedule
{

    public class ScheduleWithDates : UserActivityModel
    {
        [Key]
        public int ScheduleWithDatesId { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime ScheduleDates { get; set; }
        public decimal hours { get; set; }
        public virtual Schedule Schedules { get; set; }



    }
}