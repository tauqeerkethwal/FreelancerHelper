using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Model.Models.Base
{
    public abstract class BaseModel
    {
        public long Id { get; set; }
        public int SNo { get; set; }

    }
}
