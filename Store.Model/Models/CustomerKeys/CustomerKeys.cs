using System;
using System.ComponentModel.DataAnnotations;
namespace Freelancer.Model.Models.CustomerKeys
{
    public class CustomerKeys
    {
        public CustomerKeys()
        {
            DateCreated = DateTime.Now;

        }
        [Key]
        public int KeyId { get; set; }
        public string Name { get; set; }

        public Guid CustomerId { get; set; }
        public DateTime DateCreated { get; set; }

        public bool del { get; set; }

    }
}
