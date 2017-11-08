
using Freelancer.Model.Models.CustomerPet;
using System.Data.Entity.ModelConfiguration;
namespace Freelancer.Data.Configuration
{
    public class CustomerPetConfiguration : EntityTypeConfiguration<CustomerPet>
    {
        public CustomerPetConfiguration()
        {
            ToTable("CustomerPet");
            Property(c => c.CustPetId).IsRequired();
            Property(c => c.AnimalId).IsRequired();
            Property(c => c.CustomerId).IsRequired();
        }
    }
}
