using Freelancer.Model.Models.Employee;
using System.Data.Entity.ModelConfiguration;

namespace Freelancer.Data.Configuration
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employee");
            Property(c => c.EmployeeId).IsRequired();
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.TypeId).IsRequired();
        }
    }
}
