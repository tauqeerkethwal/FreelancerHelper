using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.CustomerKeys;
namespace Freelancer.Data.Repositories
{

    public class CustomerKeysRepository : RepositoryBase<CustomerKeys>, ICustomerKeysRepository
    {
        public CustomerKeysRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }


        public override void Update(CustomerKeys customerKeys)
        {

            base.Update(customerKeys);

        }
    }

    public interface ICustomerKeysRepository : IRepository<CustomerKeys>
    {




    }
}
