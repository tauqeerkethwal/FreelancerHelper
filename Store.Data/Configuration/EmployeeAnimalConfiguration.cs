using Freelancer.Model;
using System.Data.Entity.ModelConfiguration;
namespace Freelancer.Data.Configuration
{
    public class EmployeeAnimalConfiguration : EntityTypeConfiguration<EmployeeAnimal>
    {
        public EmployeeAnimalConfiguration()
        {
            ToTable("EmployeeAnimal");
            Property(c => c.EmpAnimalId).IsRequired();
            Property(c => c.AnimalId).IsRequired();
            Property(c => c.EmployeeId).IsRequired();
        }
    }
}
