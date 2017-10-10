using Freelancer.Model.Models.CustomerKeys;
using Freelancer.Model.Models.CustomerPet;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        { }

        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public List<CustomerKeys> CustomerKeysList { get; set; }
        public List<CustomerPet> PetCollection { get; set; }
        public SelectList PetList { get; set; }
        public int? PetId { get; set; }
        public string Name { get; set; }
        public Nullable<short> Gender { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public double HourlyRate { get; set; }
        public string CVR { get; set; }
        public string EAN { get; set; }
        public string WebSite { get; set; }
        public string Tlf { get; set; }
        public string Description { get; set; }
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
        public DateTime DateCreated { get; set; }
        public SelectList Type { get; set; }
        public int TypeId { get; set; }



    }
}