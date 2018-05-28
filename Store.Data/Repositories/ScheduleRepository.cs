using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Schedule;
using System.Linq;
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

        //public override void Update(Customer customer)
        //{

        //    base.Update(customer);

        //}
    }

    public interface IScheduleRepository : IRepository<Schedule>
    {

        Schedule GetScheduleByCustomerId(string CustomerId);


    }
}
