using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Freelancer.Data.Repositories
{
    public interface IDayScheduleRepository : IRepository<DaySchedule>
    {

        IEnumerable<DaySchedule> GetDayScheduleByScheduleId(Guid ScheduleId);
        void DeleteDaySchedule(Guid ScheduleId);
        void CreateDayScheudle(DaySchedule daySchedule);

    }
    public class DayScheduleRepository : RepositoryBase<DaySchedule>, IDayScheduleRepository
    {
        public DayScheduleRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<DaySchedule> GetDayScheduleByScheduleId(Guid ScheduleId)
        {
            var DaySchedule = this.DbContext.DaySchedules.Where(x => x.ScheduleId == ScheduleId && x.del == false);
            return DaySchedule;
        }
        public void CreateDayScheudle(DaySchedule daySchedule)
        {
           
                this.DbContext.DaySchedules.Add(daySchedule);
           

        }
        public  void DeleteDaySchedule(Guid ScheduleId)
        {

            var daySchedule = GetDayScheduleByScheduleId(ScheduleId);
            foreach (var dSchedule in daySchedule)
            {
                dSchedule.del = true;
                base.Update(dSchedule);
            }

            
           
        }
    }
}
