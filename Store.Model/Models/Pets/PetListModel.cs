using System;

namespace Freelancer.Model.Models.Pets
{
    public class PetListModel
    {
        public int SNo { get; set; }
        public int AnimalId { get; set; }
        public string Name { get; set; }

        public DateTime? DateCreated { get; set; }
        public bool del { get; set; }
    }
}
