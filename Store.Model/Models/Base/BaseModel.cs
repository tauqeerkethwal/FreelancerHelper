using System;

namespace Freelancer.Model.Models.Base
{
    public abstract class BaseModel
    {
        public long Id { get; set; }
        public int SNo { get; set; }

    }
    public abstract class UserActivityModel
    {
        public bool del { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedById { get; set; }

        public string CreatedById { get; set; }
    }
}
