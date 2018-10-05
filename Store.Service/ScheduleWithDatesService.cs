using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.EmployeePet;
using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.Schedule;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Freelancer.Service
{
    public interface IScheduleWithDatesService
    {
        void CreateAndUpdateSchedulewithDated(Schedule oldSchedule, List<ScheduleWithDates> NewSchedule);
        List<ScheduleWithDates> CompareExistingDatesFromScheduleDates(Schedule oldSchedule, List<ScheduleWithDates> NewScheduleDates);
        void SoftdeleteScheduleDates(Guid scheduleID, string UpdateUserID);
        void SaveScheduleWithDates();
    }
    public class ScheduleWithDatesService : IScheduleWithDatesService
    {
        private readonly IScheduleDatesRepository _scheduleDatesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public void SoftdeleteScheduleDates(Guid scheduleID, string UpdateUserID)
        {
            foreach (var li in _scheduleDatesRepository.GetMany(x => x.ScheduleId == scheduleID).ToList())
            {
                li.UpdatedById = UpdateUserID;
                li.del = true;
            };
        }
           

        public List<ScheduleWithDates> IfoldScheduledateNotExistInNewList(Schedule oldSchedule, List<ScheduleWithDates> NewScheduleDates)
        {
            List<ScheduleWithDates> SelectedScheduleDates = new List<ScheduleWithDates>();
            if (oldSchedule.ScheduleWithDatess != null)
            {
                for (int i = 0; i < oldSchedule.ScheduleWithDatess.Count; i++)
                {
                    bool checkold = true;

                    for (int j = 0; j < NewScheduleDates.Count; j++)
                    {
                        if (NewScheduleDates[j].ScheduleDates == oldSchedule.ScheduleWithDatess[i].ScheduleDates)
                        {
                            checkold = false;
                        }
                    }
                    if (checkold)
                        SelectedScheduleDates.Add(oldSchedule.ScheduleWithDatess[i]);
                }

            }
            return SelectedScheduleDates;
        }

        public List<ScheduleWithDates> CompareExistingDatesFromScheduleDates(Schedule oldSchedule, List<ScheduleWithDates> NewScheduleDates)
        {

            List<ScheduleWithDates> SelectedScheduleDates = new List<ScheduleWithDates>();
            for (int i = 0; i < NewScheduleDates.Count; i++)
            {
                bool checkold = true;
                if (oldSchedule.ScheduleWithDatess == null)
                {
                    SelectedScheduleDates.Add(NewScheduleDates[i]);
                }
                else
                {
                    for (int j = 0; j < oldSchedule.ScheduleWithDatess.Count; j++)
                    {
                        if (NewScheduleDates[i].ScheduleDates == oldSchedule.ScheduleWithDatess[j].ScheduleDates)
                        {
                            checkold = false;
                        }
                    }
                    if (checkold)
                    {
                        NewScheduleDates[i].ScheduleId = oldSchedule.ScheduleId;
                        SelectedScheduleDates.Add(NewScheduleDates[i]);
                    }

                }
            }

            return SelectedScheduleDates;
        }

        public void CreateAndUpdateSchedulewithDated(Schedule oldSchedule, List<ScheduleWithDates> NewScheduleDates)
        {

            _scheduleDatesRepository.SoftDeleteScheduleDates(
            IfoldScheduledateNotExistInNewList(oldSchedule, NewScheduleDates));

            _scheduleDatesRepository.CreateScheduleDates(CompareExistingDatesFromScheduleDates(oldSchedule, NewScheduleDates));


        }
        public ScheduleWithDatesService(IScheduleDatesRepository scheduleDatesRepository, IUnitOfWork unitOfWork)
        {
            _scheduleDatesRepository = scheduleDatesRepository;
            _unitOfWork = unitOfWork;
        }

        public void SaveScheduleWithDates()
        {
            _unitOfWork.Commit();
        }
    }
}

