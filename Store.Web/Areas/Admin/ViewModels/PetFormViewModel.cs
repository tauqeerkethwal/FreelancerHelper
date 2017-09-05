using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class PetFormViewModel
    {
        public PetFormViewModel()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Please enter Pet Name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }

    }
}