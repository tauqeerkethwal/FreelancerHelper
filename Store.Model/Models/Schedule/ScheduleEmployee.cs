using Freelancer.Model.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Schedule
{
    public class ScheduleEmployee : UserActivityModel
    {
        [Key]
        public int ScheduleEmployeeId { get; set; }
        public Guid ScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public virtual Schedule Schedules { get; set; }



    }
}
