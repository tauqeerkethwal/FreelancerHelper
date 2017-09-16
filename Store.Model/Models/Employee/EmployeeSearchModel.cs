using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Employee
{
    public class EmployeeSearchModel
    {

        [Key]
        public string EmployeeId { get; set; }
        public string Name { get; set; }

    }
}
