using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Pets
{
    public class Pet
    {
        public Pet()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }
        public bool del { get; set; }

    }
}
