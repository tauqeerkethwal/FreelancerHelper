using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.EmployeeType;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class TypeRepository : RepositoryBase<EmployeeType>, ITypeRepository
    {
        public TypeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }



        public IEnumerable<EmployeeType> GetAnimalName(string Name)
        {
            var employeetype = this.DbContext.EmployeeTypes.Where(x => x.Name == Name && x.del == false);
            return employeetype;
        }
        public override void Update(EmployeeType employeeType)
        {

            base.Update(employeeType);

        }
    }

    public interface ITypeRepository : IRepository<EmployeeType>
    {


        IEnumerable<EmployeeType> GetAnimalName(string Name);
    }
}
