using AutoMapper;
using Freelancer.Model.Common;
using Freelancer.Model.Models.Schedule;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Collections;
using Freelancer.Model.Models.Schedule;
namespace Freelancer.Web.Areas.Admin.Controllers
{
    public class SchedulerController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly IEmployeeService _employeeService;
        private readonly IScheduleEmployeeService _scheduleEmployeeService;
        private readonly IDayScheduleService _dayScheduleService;
        private readonly IWeekScheduleService _weekScheduleService;
        private readonly string adminid = "65AA0C14-037F-44DA-9EBA-0CF58F4B7B3A";
        // GET: Admin/Scheduler
        public SchedulerController(IScheduleService _scheduleService, IEmployeeService _employeeService, IScheduleEmployeeService _scheduleEmployeeService, IDayScheduleService dayScheduleService, IWeekScheduleService weekScheduleService)
        {
            this._scheduleEmployeeService = _scheduleEmployeeService;
            this._scheduleService = _scheduleService;
            this._employeeService = _employeeService;
            this._dayScheduleService = dayScheduleService;
            this._weekScheduleService = weekScheduleService;
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
                if (daySchedule[i].Type == (int)DayType.NormalDays)
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
                if (daySchedule[i].Type == (int)DayType.WishDays)
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
        public List<WeekSchedule> ConvertWeekModelToWeekSchedule(WeekModel weekSchedule, Guid scheduleId)
        {
            List<WeekSchedule> finalList = new List<WeekSchedule>();



            if (weekSchedule.EvenWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.EvenWeek,
                    hours = weekSchedule.EvenWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }
            if (weekSchedule.OddWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.OddWeek,
                    hours = weekSchedule.OddWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });
            }

            if (weekSchedule.EveryWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.EveryWeek,
                    hours = weekSchedule.EveryWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                }
                );

            }
            if (weekSchedule.Every1stWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every1stWeek,
                    hours = weekSchedule.Every1stWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }

            if (weekSchedule.Every2ndWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every2ndWeek,
                    hours = weekSchedule.Every2ndWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()

                });

            }

            if (weekSchedule.Every3rdWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every3rdWeek,
                    hours = weekSchedule.Every3rdWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }

            if (weekSchedule.Every4thWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every4thWeek,
                    hours = weekSchedule.Every4thWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }
            if (weekSchedule.Every5thWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every5thWeek,
                    hours = weekSchedule.Every5thWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }

            if (weekSchedule.EveryLastWeek)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.EveryLastWeek,
                    hours = weekSchedule.EveryLastWeekHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }





            return finalList;
        }


        public List<DaySchedule> ConvertDayModelToDaySchedule(List<DaysModel> daySchedule, Guid scheduleId)
        {

            List<DaySchedule> finalList = new List<DaySchedule>();

            DaysModel NormalDays = new DaysModel();
            DaysModel WishDays = new DaysModel();
            for (int i = 0; i < daySchedule.Count; i++)
            {
                Guid DayScheduleID = Guid.NewGuid();
                List<DaysWithTime> daywithTime = new List<DaysWithTime>();
                if (daySchedule[i].Friday)
                {
                    daywithTime.Add(new DaysWithTime
                    {
                        CreatedById = adminid,
                        DateCreated = DateTime.Now,
                        del = false,
                        DayWithTimeId = Guid.NewGuid(),
                        DayScheduleId = DayScheduleID,
                        Day = (int)Days.Fridag,
                        Endtime = daySchedule[i].FridayEndTime,
                        Starttime = daySchedule[i].FridayStartTime,
                    });
                }


                if (daySchedule[i].Saturday)
                {
                    daywithTime.Add(new DaysWithTime
                    {
                        CreatedById = adminid,
                        DateCreated = DateTime.Now,
                        del = false,
                        DayWithTimeId = Guid.NewGuid(),
                        DayScheduleId = DayScheduleID,
                        Day = (int)Days.Lørdag,
                        Endtime = daySchedule[i].SaturdayEndTime,
                        Starttime = daySchedule[i].SaturdayStartTime,
                    });
                }

                if (daySchedule[i].Sunday)
                {
                    daywithTime.Add(new DaysWithTime
                    {
                        CreatedById = adminid,
                        DateCreated = DateTime.Now,
                        del = false,
                        DayWithTimeId = Guid.NewGuid(),
                        DayScheduleId = DayScheduleID,
                        Day = (int)Days.Søndag,
                        Endtime = daySchedule[i].SundayEndTime,
                        Starttime = daySchedule[i].SundayStartTime,
                    });
                }
                if (daySchedule[i].Monday)
                {
                    daywithTime.Add(new DaysWithTime
                    {
                        CreatedById = adminid,
                        DateCreated = DateTime.Now,
                        del = false,
                        DayWithTimeId = Guid.NewGuid(),
                        DayScheduleId = DayScheduleID,
                        Day = (int)Days.Mandag,
                        Endtime = daySchedule[i].MondayEndTime,
                        Starttime = daySchedule[i].MondayStartTime,
                    });
                }

                if (daySchedule[i].Tuesday)
                {
                    daywithTime.Add(new DaysWithTime
                    {
                        CreatedById = adminid,
                        DateCreated = DateTime.Now,
                        del = false,
                        DayWithTimeId = Guid.NewGuid(),
                        DayScheduleId = DayScheduleID,
                        Day = (int)Days.Tirsdag,
                        Endtime = daySchedule[i].TuesdayEndTime,
                        Starttime = daySchedule[i].TuesdayStartTime,
                    });
                }
                if (daySchedule[i].Wednesday)
                {
                    daywithTime.Add(new DaysWithTime
                    {
                        CreatedById = adminid,
                        DateCreated = DateTime.Now,
                        del = false,
                        DayWithTimeId = Guid.NewGuid(),
                        DayScheduleId = DayScheduleID,
                        Day = (int)Days.Onsdag,
                        Endtime = daySchedule[i].WednesdayEndTime,
                        Starttime = daySchedule[i].WednesdayStartTime,
                    });
                }
                if (daySchedule[i].Thursday)
                {
                    daywithTime.Add(new DaysWithTime
                    {
                        CreatedById = adminid,
                        DateCreated = DateTime.Now,
                        del = false,
                        DayWithTimeId = Guid.NewGuid(),
                        DayScheduleId = DayScheduleID,
                        Day = (int)Days.Torsdag,
                        Endtime = daySchedule[i].ThursdayEndTime,
                        Starttime = daySchedule[i].ThursdayStartTime,
                    });
                }

                finalList.Add(new DaySchedule
                {
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    DayScheduleId = DayScheduleID,
                    DaysWithTimes = daywithTime,
                    Type = i,// 0 for normal days
                    ScheduleId=scheduleId
                    
                });
            }
             
            return finalList;
        }
        public ActionResult Index()
{

    Schedule schedule = _scheduleService.GetScheduleByCustomerId("gCD89A82-8D4D-4B73-BFB8-047C028B4CF5");
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
        Schedule schedule = _scheduleService.GetScheduleByCustomerId("gCD89A82-8D4D-4B73-BFB8-047C028B4CF5");
        if (schedule.ScheduleId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
        {
            var schedulee = Mapper.Map<ScheduleFormViewModel, Schedule>(scheduleFormViewModel);

            schedulee.CustomerId = "gCD89A82-8D4D-4B73-BFB8-047C028B4CF5";
            schedulee.ScheduleId = Guid.NewGuid();
            schedulee.WeekSchedules = ConvertWeekModelToWeekSchedule(scheduleFormViewModel.weekModel, schedulee.ScheduleId);
                    List<DaysModel> daymodel = new List<DaysModel>();
                    daymodel.Add(scheduleFormViewModel.NormalDays);
                    daymodel.Add(scheduleFormViewModel.WishDays);
                    schedulee.DaySchedules = ConvertDayModelToDaySchedule(daymodel, schedulee.ScheduleId);
            _scheduleService.CreateSchedule(schedulee);
            _scheduleService.SaveSchedule();
        }
                else
                {
                    _scheduleEmployeeService.CreateAndUpdateScheduleEmployee(schedule, scheduleFormViewModel.ScheduleEmployees);
                    _dayScheduleService.DeletePreviousDaySchedule(scheduleFormViewModel.ScheduleId, adminid);
                    Guid _dayScheduleId = Guid.NewGuid();

                    DaySchedule daySchedule = new DaySchedule();
                    List<DaySchedule> daySchedulelist = new List<DaySchedule>();
                    daySchedule.Type = (int)DayType.NormalDays;
                    daySchedule.ScheduleId = schedule.ScheduleId;

                    daySchedule.DayScheduleId = _dayScheduleId;
                    List<DaysWithTime> daysWithTimelist = new List<DaysWithTime>();
                    if (scheduleFormViewModel.NormalDays.Friday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Fridag, Starttime = scheduleFormViewModel.NormalDays.FridayStartTime, Endtime = scheduleFormViewModel.NormalDays.FridayEndTime, DayScheduleId = _dayScheduleId });
                    }
                    if (scheduleFormViewModel.NormalDays.Saturday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Lørdag, Starttime = scheduleFormViewModel.NormalDays.SaturdayStartTime, Endtime = scheduleFormViewModel.NormalDays.SaturdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.NormalDays.Sunday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Søndag, Starttime = scheduleFormViewModel.NormalDays.SundayStartTime, Endtime = scheduleFormViewModel.NormalDays.SundayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.NormalDays.Monday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Mandag, Starttime = scheduleFormViewModel.NormalDays.MondayStartTime, Endtime = scheduleFormViewModel.NormalDays.MondayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.NormalDays.Tuesday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Tirsdag, Starttime = scheduleFormViewModel.NormalDays.TuesdayStartTime, Endtime = scheduleFormViewModel.NormalDays.TuesdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.NormalDays.Wednesday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Onsdag, Starttime = scheduleFormViewModel.NormalDays.WednesdayStartTime, Endtime = scheduleFormViewModel.NormalDays.WednesdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.NormalDays.Thursday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Torsdag, Starttime = scheduleFormViewModel.NormalDays.ThursdayStartTime, Endtime = scheduleFormViewModel.NormalDays.ThursdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    daySchedule.DaysWithTimes = daysWithTimelist;
                    daySchedulelist.Add(daySchedule);
                    daySchedule = new DaySchedule();
                    daySchedule.Type = (int)DayType.WishDays;
                    daySchedule.ScheduleId = schedule.ScheduleId;
                    daySchedule.DayScheduleId = Guid.NewGuid();
                    daysWithTimelist = new List<DaysWithTime>();
                    if (scheduleFormViewModel.WishDays.Friday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Fridag, Starttime = scheduleFormViewModel.WishDays.FridayStartTime, Endtime = scheduleFormViewModel.WishDays.FridayEndTime, DayScheduleId = _dayScheduleId });
                    }
                    if (scheduleFormViewModel.WishDays.Saturday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Lørdag, Starttime = scheduleFormViewModel.WishDays.SaturdayStartTime, Endtime = scheduleFormViewModel.WishDays.SaturdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.WishDays.Sunday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Søndag, Starttime = scheduleFormViewModel.WishDays.SundayStartTime, Endtime = scheduleFormViewModel.WishDays.SundayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.WishDays.Monday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Mandag, Starttime = scheduleFormViewModel.WishDays.MondayStartTime, Endtime = scheduleFormViewModel.WishDays.MondayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.WishDays.Tuesday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Tirsdag, Starttime = scheduleFormViewModel.WishDays.TuesdayStartTime, Endtime = scheduleFormViewModel.WishDays.TuesdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.WishDays.Wednesday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Onsdag, Starttime = scheduleFormViewModel.WishDays.WednesdayStartTime, Endtime = scheduleFormViewModel.WishDays.WednesdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    if (scheduleFormViewModel.WishDays.Thursday)
                    {
                        daysWithTimelist.Add(new DaysWithTime { CreatedById = adminid, DayWithTimeId = Guid.NewGuid(), Day = (int)Days.Torsdag, Starttime = scheduleFormViewModel.WishDays.ThursdayStartTime, Endtime = scheduleFormViewModel.WishDays.ThursdayEndTime, DayScheduleId = _dayScheduleId });
                    }

                    daySchedule.DaysWithTimes = daysWithTimelist;
                    daySchedulelist.Add(daySchedule);
                    _dayScheduleService.CreateDayScheudle(daySchedulelist);
                    _scheduleEmployeeService.SaveCategory();
                    scheduleFormViewModel.EmployeeList = _employeeService.GetAllEmployeeDropdown();
                }
       
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