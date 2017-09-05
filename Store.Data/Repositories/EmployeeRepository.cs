using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Employee;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }



        public IEnumerable<Employee> GetEmployeeByEmployeeId(int EmployeeId)
        {
            var employeetype = this.DbContext.Employees.Where(x => x.EmployeeId == EmployeeId && x.del == false && x.Active == true);
            return employeetype;
        }
        public override void Update(Employee employee)
        {

            base.Update(employee);
        }
    }

    public interface IEmployeeRepository : IRepository<Employee>
    {


        IEnumerable<Employee> GetEmployeeByEmployeeId(int EmployeeId);
    }
}
