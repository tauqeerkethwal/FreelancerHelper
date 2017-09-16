using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class EmployeeFormViewModel
    {
        public EmployeeFormViewModel()
        {
            Active = true;
        }
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Enter PostCode")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Select Gender")]
        public Nullable<short> Gender { get; set; }
        [Required(ErrorMessage = "Enter Telephone nr.")]
        public string Tlf { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter HourlyPay")]
        public double HourlyPay { get; set; }
        public bool Orange { get; set; }
        public bool DrivingLicence { get; set; }
        public bool Car { get; set; }
        [Required(ErrorMessage = "Select Type")]
        public int TypeId { get; set; }

        public bool Active { get; set; }
        public bool del { get; set; }



    }
}