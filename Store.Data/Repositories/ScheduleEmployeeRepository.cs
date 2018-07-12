using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class ScheduleEmployeeRepository : RepositoryBase<ScheduleEmployee>, IScheduleEmployeeRepository
    {
        public ScheduleEmployeeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        
        public void CreateScheduleEmployee(IEnumerable<ScheduleEmployee> entity)
        {
            foreach (ScheduleEmployee scheduleEmployee in entity)
            {

                base.Add(scheduleEmployee);
            }



        }
        public void SoftDeleteScheduleEmployee(IEnumerable<ScheduleEmployee> entity)
        {
            foreach (ScheduleEmployee scheduleEmployee in entity)
            {

                ScheduleEmployee scheduleEmployeee = GetById(scheduleEmployee.ScheduleEmployeeId);

                scheduleEmployeee.DateUpdated = DateTime.Now;
                scheduleEmployee.UpdatedById = entity.FirstOrDefault().UpdatedById;
                scheduleEmployeee.del = true;
                base.Update(scheduleEmployeee);
            }



        }
    }

    public interface IScheduleEmployeeRepository : IRepository<ScheduleEmployee>
    {
        void CreateScheduleEmployee(IEnumerable<ScheduleEmployee> entity);
        void SoftDeleteScheduleEmployee(IEnumerable<ScheduleEmployee> entity);
        //  Schedule GetScheduleByCustomerId(string CustomerId);


    }
}
