using System.Collections.Generic;

namespace Freelancer.Model.Common
{
    public class SearchParameters
    {

        public SearchParameters()
        {
            ExtarValues = new List<KeyValuePair<string, string>>();
        }

        public string SearchText { get; set; }

        public int PageSize { get; set; }

        public int PageStart { get; set; }

        public string SortOrder { get; set; }

        public string SortColumnName { get; set; }

        public bool SortOrderDescending { get; set; }

        public List<KeyValuePair<string, string>> ExtarValues { get; set; }

    }
}
