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
    }
    public interface IScheduleDatesRepository:IRepository<ScheduleWithDates>
    { }
}
