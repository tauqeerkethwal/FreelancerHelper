using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Customer;
namespace Freelancer.Data.Repositories
{

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }


        public override void Update(Customer customer)
        {

            base.Update(customer);

        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {




    }
}
