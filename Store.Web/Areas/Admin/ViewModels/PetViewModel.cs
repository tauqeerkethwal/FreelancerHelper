using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class PetViewModel
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }




    }
}