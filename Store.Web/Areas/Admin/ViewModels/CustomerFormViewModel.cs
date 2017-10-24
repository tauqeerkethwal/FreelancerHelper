using Freelancer.Model.Models.CustomerKeys;
using Freelancer.Model.Models.CustomerPet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            Active = true;
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter Customer Id")]
        public string CustomerId { get; set; }
        public List<CustomerKeys> CustomerKeysList { get; set; }
        public List<CustomerPet> PetCollection { get; set; }

        public SelectList PetList { get; set; }
        public int? PetId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter  Street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Enter PostCode")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Select Gender")]
        public Nullable<short> Gender { get; set; }
        [Required(ErrorMessage = "Select Paymenttype")]
        public Nullable<short> Paymenttype { get; set; }

        [Required(ErrorMessage = "Enter Telephone nr.")]
        public string Tlf { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Enter Rate")]
        public double HourlyRate { get; set; }

        public string CVR { get; set; }
        public string EAN { get; set; }
        public string WebSite { get; set; }
        public string KontactPName { get; set; }
        public string KontactPTlf { get; set; }
        public string KontactPEmail { get; set; }
        public string KontactPDesc { get; set; }
        public bool IsKeys { get; set; }
        public bool IsAlarm { get; set; }
        public string AlarmDesc { get; set; }
        public bool IsOther { get; set; }
        public string OtherDesc { get; set; }
        public bool del { get; set; }
        public bool Active { get; set; }
        public int TypeId { get; set; }


    }
}