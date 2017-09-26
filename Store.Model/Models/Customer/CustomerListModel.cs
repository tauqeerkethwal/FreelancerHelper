using System;
using System.Collections.Generic;
using Freelancer.Model.Models.CustomerKeys;

namespace Freelancer.Model.Models.Customer
{
    public class CustomerListModel
    {
        public int SNo { get; set; }
        public Guid Id { get; set; }
        public List<Freelancer.Model.Models.CustomerKeys.CustomerKeys> CustomerKeysList { get; set; }
        public string CustomerId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Tlf { get; set; }
        public string Email { get; set; }
        public double? HourlyRate { get; set; }
        public string CVR { get; set; }
        public string EAN { get; set; }
        public string Type { get; set; }
        public bool? Active { get; set; }
        public bool del { get; set; }

    }
}
