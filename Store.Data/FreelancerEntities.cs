using Freelancer.Data.Configuration;
using Freelancer.Model;
using Freelancer.Model.Models.Customer;
using Freelancer.Model.Models.CustomerKeys;
using Freelancer.Model.Models.CustomerPet;
using Freelancer.Model.Models.Employee;
using Freelancer.Model.Models.EmployeePet;
using Freelancer.Model.Models.EmployeeType;
using Freelancer.Model.Models.Pets;
using Freelancer.Model.Models.Schedule;
using System.Data.Entity;

namespace Freelancer.Data
{
    public class FreelancerEntities : DbContext
    {
        public FreelancerEntities() : base("FreelancerEntities")
        {

            Database.SetInitializer<FreelancerEntities>(null);
        }
        public DbSet<CustomerKeys> CustomerKey { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPet> CustomerPets { get; set; }
        public DbSet<EmployeePet> EmployeePets { get; set; }
        public DbSet<Pet> Animals { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<WeekSchedule> WeekSchedules { get; set; }
        public DbSet<DaySchedule> DaySchedules { get; set; }
        public DbSet<ScheduleEmployee> ScheduleEmployees { get; set; }

        public DbSet<ScheduleWithDates> ScheduleWithDatess { get; set; }

        public DbSet<DaysWithTime> DaysWithTimes { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ScheduleDatesConfiguration());
            modelBuilder.Configurations.Add(new DaysWithTimeConfiguration());
            modelBuilder.Configurations.Add(new ScheduleEmployeeConfiguration());
            modelBuilder.Configurations.Add(new WeekScheduleConfiguration());
            modelBuilder.Configurations.Add(new DayScheduleConfiguration());
            modelBuilder.Configurations.Add(new ScheduleConfiguration());
            modelBuilder.Configurations.Add(new CustomerKeysConfiguration());
            modelBuilder.Configurations.Add(new EmployeePetConfiguration());
            modelBuilder.Configurations.Add(new CustomerPetConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new PetConfiguration());
            modelBuilder.Configurations.Add(new EmployeeTypeConfiguration());
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
