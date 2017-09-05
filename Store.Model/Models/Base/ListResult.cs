using System.Collections.Generic;

namespace Freelancer.Model.Models.Base
{
    public class ListResult<T>
    {


        public int TotalRecords { get; set; }

        public List<T> ResultData { get; set; }

    }
}
