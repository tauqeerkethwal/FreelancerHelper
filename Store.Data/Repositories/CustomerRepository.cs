using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Customer;
using Freelancer.Model.Models.Pets;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }



        public IEnumerable<Pet> GetAnimalName(string Name)
        {
            var employeetype = this.DbContext.Animals.Where(x => x.Name == Name && x.del == false);
            return employeetype;
        }
        public override void Update(Customer customer)
        {

            base.Update(customer);

        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {


        IEnumerable<Pet> GetAnimalName(string Name);
    }
}
