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
        private readonly IScheduleWithDatesService _scheduleWithDatesService;
        private readonly string adminid = "65AA0C14-037F-44DA-9EBA-0CF58F4B7B3A";
        // GET: Admin/Scheduler
        public SchedulerController(IScheduleService _scheduleService, IEmployeeService _employeeService, IScheduleEmployeeService _scheduleEmployeeService, IDayScheduleService dayScheduleService, IWeekScheduleService weekScheduleService, IScheduleWithDatesService scheduleWithDatesService)
        {
            this._scheduleEmployeeService = _scheduleEmployeeService;
            this._scheduleService = _scheduleService;
            this._employeeService = _employeeService;
            this._dayScheduleService = dayScheduleService;
            this._weekScheduleService = weekScheduleService;
            this._scheduleWithDatesService = scheduleWithDatesService;
        }

        public WeekModel FillWeeks(List<WeekSchedule> weekSchedule)
        {
            WeekModel finalList = new WeekModel();

            for (int i = 0; i < weekSchedule.Count; i++)
            {



                switch (weekSchedule[i].WeekType)
                {
                    case (int)WeekTypes.EveryWeekofYear:
                        finalList.EveryWeekofYear = true;
                        finalList.EveryWeekofYearHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.Every2ndWeekofYear:
                        finalList.Every2ndWeekofYear = true;
                        finalList.Every2ndWeekofYearHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.Every3rdWeekofYear:
                        finalList.Every3rdWeekofYear = true;
                        finalList.Every3rdWeekofYearHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.Every4thWeekofYear:
                        finalList.Every4thWeekofYear = true;
                        finalList.Every4thWeekofYearHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.FirstWeekOfMonth:
                        finalList.FirstWeekOfMonth = true;
                        finalList.FirstWeekOfMonthHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.SecondWeekOfMonth:
                        finalList.SecondWeekOfMonth = true;
                        finalList.SecondWeekOfMonthHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.ThirdWeekOfMonth:
                        finalList.ThirdWeekOfMonth = true;
                        finalList.ThirdWeekOfMonthHours = weekSchedule[i].hours;
                        break;

                    case (int)WeekTypes.FourthWeekOfMonth:
                        finalList.FourthWeekOfMonth = true;
                        finalList.FourthWeekOfMonthHours = weekSchedule[i].hours;
                        break;
                    case (int)WeekTypes.LastWeekOfMonth:
                        finalList.LastWeekOfMonth = true;
                        finalList.LastWeekOfMonthHours = weekSchedule[i].hours;
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



            if (weekSchedule.EveryWeekofYear)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.EveryWeekofYear,
                    hours = weekSchedule.EveryWeekofYearHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }
            if (weekSchedule.Every2ndWeekofYear)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every2ndWeekofYear,
                    hours = weekSchedule.Every2ndWeekofYearHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });
            }

            if (weekSchedule.Every3rdWeekofYear)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every3rdWeekofYear,
                    hours = weekSchedule.Every3rdWeekofYearHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                }
                );

            }
            if (weekSchedule.Every4thWeekofYear)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.Every4thWeekofYear,
                    hours = weekSchedule.Every4thWeekofYearHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }

            if (weekSchedule.FirstWeekOfMonth)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.FirstWeekOfMonth,
                    hours = weekSchedule.FirstWeekOfMonthHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()

                });

            }

            if (weekSchedule.SecondWeekOfMonth)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.SecondWeekOfMonth,
                    hours = weekSchedule.SecondWeekOfMonthHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }

            if (weekSchedule.ThirdWeekOfMonth)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.ThirdWeekOfMonth,
                    hours = weekSchedule.ThirdWeekOfMonthHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }
            if (weekSchedule.FourthWeekOfMonth)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.FourthWeekOfMonth,
                    hours = weekSchedule.FourthWeekOfMonthHours,
                    ScheduleId = scheduleId,
                    CreatedById = adminid,
                    DateCreated = DateTime.Now,
                    del = false,
                    ScheduleWeekId = Guid.NewGuid()
                });

            }

            if (weekSchedule.LastWeekOfMonth)
            {
                finalList.Add(new WeekSchedule
                {
                    WeekType = (int)WeekTypes.LastWeekOfMonth,
                    hours = weekSchedule.LastWeekOfMonthHours,
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
                    ScheduleId = scheduleId

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
                    _scheduleWithDatesService.CreateAndUpdateSchedulewithDated(schedule, scheduleFormViewModel.ScheduleWithDatess);
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

        [HttpPost]
        public ActionResult AddScheduleDates(int index, List<ScheduleWithDates> ScheduleDates)
        {
            List<ScheduleWithDates> ScheduleEmployeelist = new List<ScheduleWithDates>();
            ScheduleEmployeelist.Add(new ScheduleWithDates());
            Tuple<List<ScheduleWithDates>, int> tuple = new Tuple<List<ScheduleWithDates>, int>(ScheduleDates == null ? ScheduleEmployeelist : ScheduleDates, index);
            return PartialView("_ScheduleDates", tuple);

        }
        [HttpPost]
        public ActionResult RemoveScheduleDates(int index, List<ScheduleWithDates> ScheduleDates)
        {
            Tuple<List<ScheduleWithDates>, int> tuple = new Tuple<List<ScheduleWithDates>, int>(ScheduleDates, index);
            return PartialView("_ScheduleDates", tuple);
        }
    }
}