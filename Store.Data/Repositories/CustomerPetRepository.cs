using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.CustomerPet;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class CustomerPetRepository : RepositoryBase<CustomerPet>, ICustomerPetRepository
    {
        public CustomerPetRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<CustomerPet> GetPetsByCustomerId(Guid CustomerId)
        {
            var employeetype = this.DbContext.CustomerPets.Where(x => x.CustomerId == CustomerId && x.del == false);
            return employeetype;
        }


        public override void Update(CustomerPet employeeAnimal)
        {

            base.Update(employeeAnimal);
        }
    }

    public interface ICustomerPetRepository : IRepository<CustomerPet>
    {

        IEnumerable<CustomerPet> GetPetsByCustomerId(Guid CustomerId);

    }
}
