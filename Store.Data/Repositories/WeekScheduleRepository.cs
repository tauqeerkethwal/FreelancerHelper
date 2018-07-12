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
        public IEnumerable<WeekSchedule> GetWeekScheduleByScheduleId(Guid ScheduleId)
        {
            var WeekSchedule = this.DbContext.WeekSchedules.Where(x => x.ScheduleId == ScheduleId && x.del == false);
            return WeekSchedule;
        }
        public void DeleteWeekSchedule(Guid ScheduleId, string UpdatedByID)
        {

            var WeekSchedule = GetWeekScheduleByScheduleId(ScheduleId);
            foreach (var weekSchedule in WeekSchedule)
            {
                weekSchedule.del = true;
                weekSchedule.DateUpdated = DateTime.Now;
                weekSchedule.UpdatedById = UpdatedByID;
                base.Update(weekSchedule);
            }



        }
        public override void Update(WeekSchedule weekSchedule)
        {

            base.Update(weekSchedule);

        }
        public void CreateWeekSchedule(WeekSchedule weekSchedule)
        {

            this.DbContext.WeekSchedules.Add(weekSchedule);


        }
    }
    public interface IWeekScheduleRepository :IRepository<WeekSchedule>
    {
        void DeleteWeekSchedule(Guid ScheduleId, string UpdatedByID);
        IEnumerable<WeekSchedule> GetWeekScheduleByScheduleId(Guid ScheduleId);
        IEnumerable<WeekSchedule> GetAllWeekScheduleByWeekType(int WeekType);
        void CreateWeekSchedule(WeekSchedule weekSchedule);
    }
}
