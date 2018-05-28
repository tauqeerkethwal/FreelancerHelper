using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.Schedule;
using System.Collections.Generic;
using System.Linq;

namespace Freelancer.Service
{
    // operations you want to expose
    public interface IScheduleService
    {
        //
        Schedule GetScheduleByCustomerId(string CustomerId);
        void CreateSchedule(Schedule schedule);
        void SaveSchedule();
    }

    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository scheduleRepository;
        private readonly IUnitOfWork unitOfWork;

        public ScheduleService(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        {
            this.scheduleRepository = scheduleRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public Schedule GetScheduleByCustomerId(string CustomerId)
        {
            return scheduleRepository.GetMany(x => x.CustomerId == CustomerId && x.del == false).ToList().Select(c => new Schedule()
            {
                DaySchedules = c.DaySchedules.Where(x => x.del == false).ToList().Select(a => new DaySchedule()
                {
                    DaysWithTimes = a.DaysWithTimes.Where(x => x.del == false).ToList(),
                    CreatedById = a.CreatedById,
                    DateCreated = a.DateCreated,
                    DateUpdated = a.DateUpdated,
                    DayScheduleId = a.DayScheduleId,
                    del = a.del,
                    ScheduleId = a.ScheduleId,
                    Type = a.Type,
                    UpdatedById = a.UpdatedById,


                }).ToList(),
                WeekSchedules = c.WeekSchedules.Where(x => x.del == false).ToList().Select(d => new WeekSchedule()
                {


                    CreatedById = d.CreatedById,
                    DateCreated = d.DateCreated,
                    DateUpdated = d.DateUpdated,
                    del = d.del,
                    hours = d.hours,
                    ScheduleId = d.ScheduleId,
                    Schedules = d.Schedules,
                    ScheduleWeekId = d.ScheduleWeekId,
                    UpdatedById = d.UpdatedById,
                    WeekType = d.WeekType
                }).ToList(),
                ScheduleEmployees = c.ScheduleEmployees.Where(x => x.del == false).ToList().Select(e => new ScheduleEmployee()
                {
                    CreatedById = e.CreatedById,
                    DateCreated = e.DateCreated,
                    DateUpdated = e.DateUpdated,
                    del = e.del,
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    ScheduleEmployeeId = e.ScheduleEmployeeId,
                    ScheduleId = e.ScheduleId,
                    Schedules = e.Schedules,

                    UpdatedById = e.UpdatedById

                }
               ).ToList()
               ,
                CreatedById = c.CreatedById,
                CustomerId = c.CustomerId,
                DateCreated = c.DateCreated,
                DateUpdated = c.DateUpdated,
                del = c.del,

                ScheduleId = c.ScheduleId,
                UpdatedById = c.UpdatedById

            }

                ).DefaultIfEmpty(new Schedule()
                {
                    CustomerId = CustomerId,
                    DaySchedules = new List<DaySchedule>(),
                    WeekSchedules = new List<WeekSchedule>()
                }).First();



        }

        public void SaveSchedule()
        {
            unitOfWork.Commit();
        }
        public void CreateSchedule(Schedule schedule)
        {
            scheduleRepository.Add(schedule);
        }
        #endregion
    }
}
