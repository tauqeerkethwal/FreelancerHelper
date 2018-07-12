using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelancer.Model.Models.Schedule;
using Freelancer.Data.Repositories;
using Freelancer.Data.Infrastructure;
namespace Freelancer.Service
{
    public interface IWeekScheduleService
    {
        IEnumerable<WeekSchedule> GetAllWeekScheduleByWeekType(int weekType);

        IEnumerable<WeekSchedule> GetAllWeekScheduleByScheduleId(Guid scheduleId);
        IEnumerable<WeekSchedule> GetDeletedWeekScheduleByScheduleId(Guid scheduleId);

        IEnumerable<WeekSchedule> GetAllActiveWeekScheduleByScheduleId(Guid scheduleId);
        WeekSchedule GetWeekSchedule(Guid ScheduleWeekId);
       
        void CreateWeekSchedule(WeekSchedule weekSchedule);
        void CreateWeekSchedules(List<WeekSchedule> weekSchedule);
        void DeletePreviousWeekSchedule(Guid ScheduleId, string UpdatedByID);

        void Update(WeekSchedule weekSchedule);
       
        void SaveWeekSchedule();

    }
    public class WeekScheduleService: IWeekScheduleService
    {
        private readonly IWeekScheduleRepository _weekScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public void CreateWeekSchedules(List<WeekSchedule> weekSchedule)
        {
            foreach (var dSchedule in weekSchedule)
            {
                _weekScheduleRepository.CreateWeekSchedule(dSchedule);
            }

        }
        public IEnumerable<WeekSchedule> GetAllWeekScheduleByScheduleId(Guid scheduleId)
        {
            return _weekScheduleRepository.GetMany(x => x.ScheduleId == scheduleId);
        }
        public IEnumerable<WeekSchedule> GetAllActiveWeekScheduleByScheduleId(Guid scheduleId)
        {
            return _weekScheduleRepository.GetMany(x => x.ScheduleId == scheduleId && x.del == false);
        }
        public IEnumerable<WeekSchedule> GetDeletedWeekScheduleByScheduleId(Guid scheduleId)
        {
            return _weekScheduleRepository.GetMany(x => x.ScheduleId == scheduleId && x.del==true);
        }
        public void DeletePreviousWeekSchedule(Guid ScheduleId, string UpdatedByID)
        {
            _weekScheduleRepository.DeleteWeekSchedule(ScheduleId, UpdatedByID);
            
        }
        public WeekScheduleService(IWeekScheduleRepository weekScheduleRepository, IUnitOfWork unitOfWork)
        {
            _weekScheduleRepository = weekScheduleRepository;
            _unitOfWork = unitOfWork;

        }
        public IEnumerable<WeekSchedule> GetAllWeekScheduleByWeekType(int weekType)
        {
           return _weekScheduleRepository.GetAllWeekScheduleByWeekType(weekType);
        }
        public WeekSchedule GetWeekSchedule(Guid ScheduleWeekId)
        {
           return _weekScheduleRepository.GetMany(x => x.ScheduleWeekId == ScheduleWeekId).FirstOrDefault();
        }
        public void CreateWeekSchedule(WeekSchedule weekSchedule)
        {
            _weekScheduleRepository.Add(weekSchedule);
        }

        public void Update(WeekSchedule weekSchedule)
        {
            _weekScheduleRepository.Update(weekSchedule);
        }

        public void SaveWeekSchedule()
        {
            _unitOfWork.Commit();
        }

    }
}
