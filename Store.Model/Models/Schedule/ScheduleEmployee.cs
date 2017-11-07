using Freelancer.Model.Models.Base;
using System;
namespace Freelancer.Model.Models.Schedule
{
    public class ScheduleEmployee : UserActivityModel
    {
        public int ScheduleEmployeeId { get; set; }
        public Guid ScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public virtual Schedule Schedules { get; set; }



    }
}
