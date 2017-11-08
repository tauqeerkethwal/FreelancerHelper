using Freelancer.Model.Models.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class WeekModel
    {

        public bool EveryWeek { get; set; }

        public double? EveryWeekHours { get; set; }

        public bool EvenWeek { get; set; }
        public double? EvenWeekHours { get; set; }
        public bool OddWeek { get; set; }
        public double? OddWeekHours { get; set; }
        public bool Every1stWeek { get; set; }
        public double? Every1stWeekHours { get; set; }
        public bool Every2ndWeek { get; set; }
        public double? Every2ndWeekHours { get; set; }
        public bool Every3rdWeek { get; set; }
        public double? Every3rdWeekHours { get; set; }
        public bool Every4thWeek { get; set; }
        public double? Every4thWeekHours { get; set; }
        public bool Every5thWeek { get; set; }
        public double? Every5thWeekHours { get; set; }
        public bool EveryLastWeek { get; set; }
        public double? EveryLastWeekHours { get; set; }


    }

    public class DaysModel
    {
        public bool Monday { get; set; }

        public TimeSpan MondayStartTime { get; set; }
        public TimeSpan MondayEndTime { get; set; }
        public bool Tuesday { get; set; }
        public TimeSpan TuesdayStartTime { get; set; }
        public TimeSpan TuesdayEndTime { get; set; }
        public bool Wednesday { get; set; }
        public TimeSpan WednesdayStartTime { get; set; }
        public TimeSpan WednesdayEndTime { get; set; }
        public bool Thursday { get; set; }
        public TimeSpan ThursdayStartTime { get; set; }
        public TimeSpan ThursdayEndTime { get; set; }
        public bool Friday { get; set; }
        public TimeSpan FridayStartTime { get; set; }
        public TimeSpan FridayEndTime { get; set; }
        public bool Saturday { get; set; }
        public TimeSpan SaturdayStartTime { get; set; }
        public TimeSpan SaturdayEndTime { get; set; }
        public bool Sunday { get; set; }
        public TimeSpan SundayStartTime { get; set; }
        public TimeSpan SundayEndTime { get; set; }

    }



    public class ScheduleFormViewModel
    {
        //: UserActivityModel
        [Key]
        public Guid ScheduleId { get; set; }
        public string CustomerId { get; set; }
        public List<ScheduleEmployee> ScheduleEmployees { get; set; }
        public WeekModel weekModel { get; set; }
        public DaysModel NormalDays { get; set; }
        public DaysModel WishDays { get; set; }
        public SelectList EmployeeList
        {
            get; set;
        }
    }

    public class ScheduleViewModel
    {
        //: UserActivityModel
        [Key]
        public Guid ScheduleId { get; set; }
        public string CustomerId { get; set; }
        public List<ScheduleEmployee> ScheduleEmployees { get; set; }
        public WeekModel weekModel { get; set; }
        public DaysModel NormalDays { get; set; }
        public DaysModel WishDays { get; set; }
        public string EmployeeId { get; set; }
        public SelectList EmployeeList
        {
            get; set;
        }
    }
}
