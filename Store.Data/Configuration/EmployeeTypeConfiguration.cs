using Freelancer.Model.Models.EmployeeType;
using System.Data.Entity.ModelConfiguration;
namespace Freelancer.Data.Configuration
{
    public class EmployeeTypeConfiguration : EntityTypeConfiguration<EmployeeType>
    {
        public EmployeeTypeConfiguration()
        {
            ToTable("EmployeeType");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
