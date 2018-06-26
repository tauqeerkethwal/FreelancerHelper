using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Freelancer.Model.Models.Schedule;
using Freelancer.Data.Infrastructure;
namespace Freelancer.Data.Repositories
{
    public class WeekScheduleRepository: RepositoryBase<WeekSchedule>, IWeekScheduleRepository
    {
        public WeekScheduleRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }

        public IEnumerable<WeekSchedule> GetAllWeekScheduleByWeekType(int WeekType)
        {
            var weekSchedule = this.DbContext.WeekSchedules.Where(x => x.WeekType == WeekType );
            return weekSchedule;
        }
        public override void Update(WeekSchedule weekSchedule)
        {

            base.Update(weekSchedule);

        }
    }
    public interface IWeekScheduleRepository :IRepository<WeekSchedule>
    {
        IEnumerable<WeekSchedule> GetAllWeekScheduleByWeekType(int WeekType);
    }
}
