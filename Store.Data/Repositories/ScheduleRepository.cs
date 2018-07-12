using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Schedule;
using System.Linq;
using System;
namespace Freelancer.Data.Repositories
{

    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public Schedule GetScheduleByCustomerId(string CustomerId)
        {
            return base.GetMany(x => x.CustomerId == CustomerId && x.del == false).ToList().SingleOrDefault();
        }

        public void UpdateStartingDateByScheduleId(Schedule entity)
        {


            Schedule schedule = GetMany(x => x.ScheduleId == entity.ScheduleId).FirstOrDefault();

                schedule.DateUpdated = DateTime.Now;
                schedule.UpdatedById = entity.UpdatedById;
                schedule.StartingDate = entity.StartingDate;
                base.Update(schedule);
            



        }
    }

    public interface IScheduleRepository : IRepository<Schedule>
    {

        Schedule GetScheduleByCustomerId(string CustomerId);
        void UpdateStartingDateByScheduleId(Schedule entity);

    }
}
