using AutoMapper;
using Freelancer.Model.Common;
using Freelancer.Model.Models.Schedule;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.Controllers
{
    public class SchedulerController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly IEmployeeService _employeeService;
        private readonly IScheduleEmployeeService _scheduleEmployeeService;
        // GET: Admin/Scheduler
        public SchedulerController(IScheduleService _scheduleService, IEmployeeService _employeeService, IScheduleEmployeeService _scheduleEmployeeService)
        {
            this._scheduleEmployeeService = _scheduleEmployeeService;
            this._scheduleService = _scheduleService;
            this._employeeService = _employeeService;
        }
        public WeekModel FillWeeks(List<WeekSchedule> weekSchedule)
        {
            WeekModel finalList = new WeekModel();

            for (int i = 0; i < weekSchedule.Count; i++)
            {



                switch (weekSchedule[i].WeekType)
                {
                    case (int)WeekTypes.EvenWeek:
                        finalList.EvenWeek = true;
                        finalList.EvenWeekHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.OddWeek:
                        finalList.OddWeek = true;
                        finalList.OddWeekHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.EveryWeek:
                        finalList.EveryWeek = true;
                        finalList.EveryWeekHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.Every1stWeek:
                        finalList.Every1stWeek = true;
                        finalList.Every1stWeekHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.Every2ndWeek:
                        finalList.Every2ndWeek = true;
                        finalList.Every2ndWeekHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.Every3rdWeek:
                        finalList.Every3rdWeek = true;
                        finalList.Every3rdWeekHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.Every4thWeek:
                        finalList.Every4thWeek = true;
                        finalList.Every4thWeekHours = weekSchedule[i].hours;
                        break;

                    case (int)WeekTypes.Every5thWeek:
                        finalList.Every5thWeek = true;
                        finalList.Every5thWeekHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.EveryLastWeek:
                        finalList.EveryLastWeek = true;
                        finalList.EveryLastWeekHours = weekSchedule[i].hours;
                        break;


                }




            }

            return finalList;
        }
        public List<DaysModel> FillDays(List<DaySchedule> daySchedule)
        {
            List<DaysModel> finalList = new List<DaysModel>();
            DaysModel NormalDays = new DaysModel();
            DaysModel WishDays = new DaysModel();
            for (int i = 0; i < daySchedule.Count; i++)
            {
                if (daySchedule[i].Type == 0)
                {

                    for (int j = 0; j < daySchedule[i].DaysWithTimes.Count; j++)
                    {
                        switch (daySchedule[i].DaysWithTimes[j].Day)
                        {
                            case (int)Days.Mandag:
                                NormalDays.Monday = true;
                                NormalDays.MondayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                NormalDays.MondayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Tirsdag:
                                NormalDays.Tuesday = true;
                                NormalDays.TuesdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                NormalDays.TuesdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Onsdag:
                                NormalDays.Wednesday = true;
                                NormalDays.WednesdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                NormalDays.WednesdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Torsdag:
                                NormalDays.Thursday = true;
                                NormalDays.ThursdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                NormalDays.ThursdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Fridag:
                                NormalDays.Friday = true;
                                NormalDays.FridayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                NormalDays.FridayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Lørdag:
                                NormalDays.Saturday = true;
                                NormalDays.SaturdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                NormalDays.SaturdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Søndag:
                                NormalDays.Sunday = true;
                                NormalDays.SundayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                NormalDays.SundayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;

                        }
                    }
                }
                if (daySchedule[i].Type == 1)
                {

                    for (int j = 0; j < daySchedule[i].DaysWithTimes.Count; j++)
                    {
                        switch (daySchedule[i].DaysWithTimes[j].Day)
                        {
                            case (int)Days.Mandag:
                                WishDays.Monday = true;
                                WishDays.MondayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                WishDays.MondayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Tirsdag:
                                WishDays.Tuesday = true;
                                WishDays.TuesdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                WishDays.TuesdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Onsdag:
                                WishDays.Wednesday = true;
                                WishDays.WednesdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                WishDays.WednesdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Torsdag:
                                WishDays.Thursday = true;
                                WishDays.ThursdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                WishDays.ThursdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Fridag:
                                WishDays.Friday = true;
                                WishDays.FridayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                WishDays.FridayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Lørdag:
                                WishDays.Saturday = true;
                                WishDays.SaturdayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                WishDays.SaturdayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;
                            case (int)Days.Søndag:
                                WishDays.Sunday = true;
                                WishDays.SundayStartTime = daySchedule[i].DaysWithTimes[j].Starttime;
                                WishDays.SundayEndTime = daySchedule[i].DaysWithTimes[j].Endtime;
                                break;


                        }
                    }
                }
            }
            finalList.Add(NormalDays);
            finalList.Add(WishDays);
            return finalList;
        }
        public ActionResult Index()
        {

            Schedule schedule = _scheduleService.GetScheduleByCustomerId("BCD89A82-8D4D-4B73-BFB8-047C028B4CF5");
            var scheduleViewModel = Mapper.Map<Schedule, ScheduleViewModel>(schedule);
            scheduleViewModel.EmployeeList = _employeeService.GetAllEmployeeDropdown();
            scheduleViewModel.NormalDays = FillDays(schedule.DaySchedules)[0];
            scheduleViewModel.WishDays = FillDays(schedule.DaySchedules)[1];
            scheduleViewModel.weekModel = FillWeeks(schedule.WeekSchedules.ToList());


            return View(scheduleViewModel);
        }

        [HttpPost]
        public ActionResult Index(ScheduleFormViewModel scheduleFormViewModel)
        {

            if (ModelState.IsValid)
            {
                Schedule schedule = _scheduleService.GetScheduleByCustomerId("BCD89A82-8D4D-4B73-BFB8-047C028B4CF5");
                if (schedule.ScheduleId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    var schedulee = Mapper.Map<ScheduleFormViewModel, Schedule>(scheduleFormViewModel);
                    schedulee.CustomerId = "BCD89A82-8D4D-4B73-BFB8-047C028B4CF5";
                    schedulee.ScheduleId = Guid.NewGuid();
                    _scheduleService.CreateSchedule(schedulee);
                    _scheduleService.SaveSchedule();
                }

                _scheduleEmployeeService.CreateAndUpdateScheduleEmployee(schedule, scheduleFormViewModel.ScheduleEmployees);
                _scheduleEmployeeService.SaveCategory();
                scheduleFormViewModel.EmployeeList = _employeeService.GetAllEmployeeDropdown();
            }
            scheduleFormViewModel.EmployeeList = _employeeService.GetAllEmployeeDropdown();
            var scheduleViewModel = Mapper.Map<ScheduleFormViewModel, ScheduleViewModel>(scheduleFormViewModel);
            return View(scheduleViewModel);
        }
        [HttpPost]
        public ActionResult AddScheduleEmployee(int index, List<ScheduleEmployee> scheduleEmployee)
        {
            List<ScheduleEmployee> ScheduleEmployeelist = new List<ScheduleEmployee>();
            ScheduleEmployeelist.Add(new ScheduleEmployee());
            Tuple<List<ScheduleEmployee>, int> tuple = new Tuple<List<ScheduleEmployee>, int>(scheduleEmployee == null ? ScheduleEmployeelist : scheduleEmployee, index);
            return PartialView("_EmployeePetRow", tuple);

        }
        [HttpPost]
        public ActionResult RemoveScheduleEmployee(int index, List<ScheduleEmployee> scheduleEmployee)
        {
            Tuple<List<ScheduleEmployee>, int> tuple = new Tuple<List<ScheduleEmployee>, int>(scheduleEmployee, index);
            return PartialView("_EmployeePetRow", tuple);
        }
    }
}