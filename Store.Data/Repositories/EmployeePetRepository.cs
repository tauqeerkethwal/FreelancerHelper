using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.EmployeePet;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class EmployeePetRepository : RepositoryBase<EmployeePet>, IEmployeePetRepository
    {
        public EmployeePetRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<EmployeePet> GetPetsByEmployeeId(int EmployeeId)
        {
            var employeetype = this.DbContext.EmployeePets.Where(x => x.EmployeeId == EmployeeId && x.del == false);
            return employeetype;
        }


        public override void Update(EmployeePet employeePet)
        {

            base.Update(employeePet);
        }
    }

    public interface IEmployeePetRepository : IRepository<EmployeePet>
    {

        IEnumerable<EmployeePet> GetPetsByEmployeeId(int EmployeeId);

    }
}
