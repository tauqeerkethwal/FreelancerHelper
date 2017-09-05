using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.EmployeeType

{

    public class EmployeeType
    {

        public EmployeeType()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int TypeId { get; set; }
        public string Name { get; set; }

        public DateTime? DateCreated { get; set; }
        public bool del { get; set; }
    }
}
