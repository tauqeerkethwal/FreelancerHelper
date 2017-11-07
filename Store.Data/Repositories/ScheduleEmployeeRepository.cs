using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Schedule;
namespace Freelancer.Data.Repositories
{

    public class ScheduleEmployeeRepository : RepositoryBase<ScheduleEmployee>, IScheduleEmployeeRepository
    {
        public ScheduleEmployeeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        //public Schedule GetScheduleByCustomerId(string CustomerId)
        //{
        //    return base.GetMany(x => x.CustomerId == CustomerId && x.del == false).ToList().SingleOrDefault();
        //}

        //public override void Update(Customer customer)
        //{

        //    base.Update(customer);

        //}
    }

    public interface IScheduleEmployeeRepository : IRepository<ScheduleEmployee>
    {

        //  Schedule GetScheduleByCustomerId(string CustomerId);


    }
}
