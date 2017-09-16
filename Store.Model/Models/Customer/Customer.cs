using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.Customer
{
    public class Customer
    {
        public Customer()
        {
            DateCreated = DateTime.Now;
            Active = true;
        }
        [Key]
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
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
        public bool Keys { get; set; }
        public bool Alarm { get; set; }
        public string AlarmDesc { get; set; }
        public bool Other { get; set; }
        public string OtherDesc { get; set; }
        public bool del { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid UpdatedById { get; set; }



    }
}
