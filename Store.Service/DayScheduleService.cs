﻿using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.Schedule;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace Freelancer.Service
{
    public interface IDayScheduleService
    {
        void DeletePreviousDaySchedule(Guid ScheduleId, string UpdatedByID);
        void CreateDayScheudle(List<DaySchedule> daySchedule);
        IEnumerable<DaySchedule> GetDayScheduleByScheduleId(Guid ScheduleId);
        void SaveDaySchedule();
    }
    public class DayScheduleService : IDayScheduleService
    {
        private readonly IDayScheduleRepository _dayScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DayScheduleService(IDayScheduleRepository dayScheduleRepository, IUnitOfWork unitofWork)
        {
            _dayScheduleRepository = dayScheduleRepository;
            _unitOfWork = unitofWork;

        }
        public void CreateDayScheudle(List<DaySchedule> daySchedule)
        {
            foreach(var dSchedule in daySchedule)
            {
                _dayScheduleRepository.CreateDayScheudle(dSchedule);
            }

        }

        public void DeletePreviousDaySchedule(Guid ScheduleId, string UpdatedByID)
        {
            _dayScheduleRepository.DeleteDaySchedule(ScheduleId,  UpdatedByID);
        }

        public IEnumerable<DaySchedule> GetDayScheduleByScheduleId(Guid ScheduleId)
        {
         return    _dayScheduleRepository.GetDayScheduleByScheduleId(ScheduleId);
        }

        public void SaveDaySchedule()
        {
            throw new NotImplementedException();
        }
    }
}