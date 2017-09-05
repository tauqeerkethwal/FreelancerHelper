using Freelancer.Data.Infrastructure;
using Freelancer.Model;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class EmployeeAnimalRepository : RepositoryBase<EmployeeAnimal>, IEmployeeAnimalRepository
    {
        public EmployeeAnimalRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }



        public IEnumerable<EmployeeAnimal> GetAnimalsByEmployeeId(int EmployeeId)
        {
            var employeetype = this.DbContext.EmployeeAnimals.Where(x => x.EmployeeId == EmployeeId && x.del == false);
            return employeetype;
        }
        public override void Update(EmployeeAnimal employeeAnimal)
        {

            base.Update(employeeAnimal);
        }
    }

    public interface IEmployeeAnimalRepository : IRepository<EmployeeAnimal>
    {


        IEnumerable<EmployeeAnimal> GetAnimalsByEmployeeId(int EmployeeId);
    }
}
