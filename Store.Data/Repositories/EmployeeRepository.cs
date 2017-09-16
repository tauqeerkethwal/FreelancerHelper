using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Employee;
namespace Freelancer.Data.Repositories
{

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }



        public override void Update(Employee employee)
        {

            base.Update(employee);
        }
    }

    public interface IEmployeeRepository : IRepository<Employee>
    {



    }
}
