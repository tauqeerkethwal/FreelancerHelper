using Freelancer.Model.Models.CustomerKeys;
using System.Data.Entity.ModelConfiguration;
namespace Freelancer.Data.Configuration
{
    public class CustomerKeysConfiguration : EntityTypeConfiguration<CustomerKeys>
    {
        public CustomerKeysConfiguration()
        {
            ToTable("CustomerKey");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
          

        }
    }
}
