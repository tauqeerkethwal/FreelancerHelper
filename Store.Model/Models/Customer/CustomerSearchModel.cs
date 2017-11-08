using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Customer
{
    public class CustomerSearchModel
    {

        [Key]
        public string CustomerId { get; set; }
        public string Name { get; set; }

    }
}
