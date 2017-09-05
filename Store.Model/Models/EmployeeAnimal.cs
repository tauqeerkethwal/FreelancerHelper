using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model
{
    public class EmployeeAnimal
    {
        public EmployeeAnimal()
        {

        }
        [Key]
        public int EmpAnimalId { get; set; }
        public int AnimalId { get; set; }
        public int EmployeeId { get; set; }
        public bool del { get; set; }
    }
}
