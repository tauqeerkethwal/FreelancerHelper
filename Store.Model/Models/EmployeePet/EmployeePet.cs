using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.EmployeePet
{
    public class EmployeePet
    {
        public EmployeePet()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int EmpPetId { get; set; }
        public int AnimalId { get; set; }
        public int EmployeeId { get; set; }
        public bool del { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
