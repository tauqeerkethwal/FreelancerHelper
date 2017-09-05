using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Pets
{
    public class PetSearchModel
    {

        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }

        public DateTime? DateCreated { get; set; }
        public bool del { get; set; }
    }
}
