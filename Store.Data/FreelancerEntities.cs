using Freelancer.Data.Configuration;
using Freelancer.Model;
using Freelancer.Model.Models.EmployeeType;
using Freelancer.Model.Models.Employee;
using Freelancer.Model.Models.Pets;
using System.Data.Entity;

namespace Freelancer.Data
{
    public class FreelancerEntities : DbContext
    {
        public FreelancerEntities() : base("FreelancerEntities")
        {

            Database.SetInitializer<FreelancerEntities>(null);
        }
        public DbSet<EmployeeAnimal> EmployeeAnimals { get; set; }
        public DbSet<Pet> Animals { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PetConfiguration());
            modelBuilder.Configurations.Add(new EmployeeTypeConfiguration());
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
