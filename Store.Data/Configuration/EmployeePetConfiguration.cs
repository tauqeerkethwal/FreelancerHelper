
using Freelancer.Model.Models.EmployeePet;
using System.Data.Entity.ModelConfiguration;
namespace Freelancer.Data.Configuration
{
    public class EmployeePetConfiguration : EntityTypeConfiguration<EmployeePet>
    {
        public EmployeePetConfiguration()
        {
            ToTable("EmployeePet");
            Property(c => c.EmpPetId).IsRequired();
            Property(c => c.AnimalId).IsRequired();
            Property(c => c.EmployeeId).IsRequired();
        }
    }
}
