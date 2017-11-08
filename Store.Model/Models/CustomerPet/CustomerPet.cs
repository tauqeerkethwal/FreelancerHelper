using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.CustomerPet
{
    public class CustomerPet
    {
        public CustomerPet()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int CustPetId { get; set; }
        public int AnimalId { get; set; }
        public Guid CustomerId { get; set; }
        public bool del { get; set; }
        public string Name { get; set; }
        public string PetName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
