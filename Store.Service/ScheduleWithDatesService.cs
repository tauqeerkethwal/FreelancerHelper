using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.EmployeePet;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Service
{
    public interface IScheduleWithDatesService
    {
        void SaveScheduleWithDates();
    }
    public class ScheduleWithDatesService : IScheduleWithDatesService
    {
        private readonly IScheduleDatesRepository _scheduleDatesRepository;
        private readonly IUnitOfWork _unitOfWork;

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

