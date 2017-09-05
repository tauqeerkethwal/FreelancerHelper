using Freelancer.Model.Models.Pets;
using System.Data.Entity.ModelConfiguration;
namespace Freelancer.Data.Configuration
{
    public class PetConfiguration : EntityTypeConfiguration<Pet>
    {
        public PetConfiguration()
        {
            ToTable("Pet");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
