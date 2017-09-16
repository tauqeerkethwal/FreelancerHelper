﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.ViewModels
{
    public class EmployeeViewModel
    {


        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }


        public Nullable<short> Gender { get; set; }
        public string Tlf { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public double HourlyPay { get; set; }
        public bool Orange { get; set; }
        public bool DrivingLicence { get; set; }
        public bool Car { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int TypeId { get; set; }
        [System.ComponentModel.DefaultValue(1)]
        public bool Active { get; set; }
        public bool del { get; set; }

        public Guid? UpdatedById { get; set; }

        public SelectList Type
        {
            get; set;



        }


    }
}