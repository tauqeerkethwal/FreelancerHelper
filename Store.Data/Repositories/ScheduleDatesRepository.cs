using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Schedule;

namespace Freelancer.Data.Repositories
{
    public class ScheduleDatesRepository: RepositoryBase<ScheduleWithDates>, IScheduleDatesRepository
    {
        public ScheduleDatesRepository(IDbFactory dbFactory)
            :base(dbFactory)
        {

        }
        public void CreateScheduleDates(IEnumerable<ScheduleWithDates> entity)
        {
            foreach (ScheduleWithDates scheduleDates in entity)
            {

                base.Add(scheduleDates);
            }



        }
        public void SoftDeleteScheduleDates(IEnumerable<ScheduleWithDates> entity)
        {
            foreach (ScheduleWithDates scheduleEmployee in entity)
            {

                ScheduleWithDates scheduleDates = GetById(scheduleEmployee.ScheduleWithDatesId);

                scheduleDates.DateUpdated = DateTime.Now;
                scheduleDates.UpdatedById = entity.FirstOrDefault().UpdatedById;
                scheduleDates.del = true;
                base.Update(scheduleDates);
            }



        }
    }
    public interface IScheduleDatesRepository:IRepository<ScheduleWithDates>
    {
        void CreateScheduleDates(IEnumerable<ScheduleWithDates> entity);
        void SoftDeleteScheduleDates(IEnumerable<ScheduleWithDates> entity);
    }
}
