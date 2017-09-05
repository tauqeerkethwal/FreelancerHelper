using System;

using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Employee
{
    public class Employee
    {
        public Employee()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Pet Name")]
        public string Gender { get; set; }
        public string Tlf { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public double HourlyPay { get; set; }
        public bool Orange { get; set; }
        public bool DrivingLicence { get; set; }
        public bool Car { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int TypeId { get; set; }
        public bool Active { get; set; }
        public bool del { get; set; }

        public Guid? UpdatedById { get; set; }

        //  public IEquatable<EmployeeAnimal> EmployeeAnimalCollection { get; set; }
    }
}
