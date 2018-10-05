using Freelancer.Model.Models.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class WeekModel
    {


        public bool EveryOddWeekOfYear { get; set; }
        public double? EveryOddWeekOfYearHours { get; set; }
        public bool EveryEvenWeekOfYear { get; set; }
        public double? EveryEvenWeekOfYearHours { get; set; }

        public bool EveryWeekofYear { get; set; }

        public double? EveryWeekofYearHours { get; set; }

        public bool Every2ndWeekofYear { get; set; }
        public double? Every2ndWeekofYearHours { get; set; }
        public bool Every3rdWeekofYear { get; set; }
        public double? Every3rdWeekofYearHours { get; set; }
        public bool Every4thWeekofYear { get; set; }
        public double? Every4thWeekofYearHours { get; set; }
        public bool FirstWeekOfMonth { get; set; }
        public double? FirstWeekOfMonthHours { get; set; }
        public bool SecondWeekOfMonth { get; set; }
        public double? SecondWeekOfMonthHours { get; set; }
        public bool ThirdWeekOfMonth { get; set; }
        public double? ThirdWeekOfMonthHours { get; set; }
        public bool FourthWeekOfMonth { get; set; }
        public double? FourthWeekOfMonthHours { get; set; }
        public bool LastWeekOfMonth { get; set; }
        public double? LastWeekOfMonthHours { get; set; }


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
        public List<ScheduleWithDates> ScheduleWithDatess { get; set; }
        public WeekModel weekModel { get; set; }
        public DaysModel NormalDays { get; set; }
        public DaysModel WishDays { get; set; }
        public DateTime StartingDate { get; set; }
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
        public List<ScheduleWithDates> ScheduleWithDatess { get; set; }
        public WeekModel weekModel { get; set; }
        public DaysModel NormalDays { get; set; }
        public DaysModel WishDays { get; set; }
        public string EmployeeId { get; set; }
        public DateTime StartingDate { get; set; }
        public SelectList EmployeeList
        {
            get; set;
        }
    }
}
