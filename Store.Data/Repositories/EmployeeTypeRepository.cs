using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.EmployeeType;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class EmployeeTypeRepository : RepositoryBase<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }



        public IEnumerable<EmployeeType> GetEmployeeTypesByName(string Name)
        {
            var employeetype = this.DbContext.EmployeeTypes.Where(x => x.Name == Name && x.del == false);
            return employeetype;
        }
        public override void Update(EmployeeType entity)
        {

            base.Update(entity);
        }
    }

    public interface IEmployeeTypeRepository : IRepository<EmployeeType>
    {


        IEnumerable<EmployeeType> GetEmployeeTypesByName(string Name);
    }
}
