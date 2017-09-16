using Freelancer.Model.Models.Customer;
using System.Data.Entity.ModelConfiguration;
namespace Freelancer.Data.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customer");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
