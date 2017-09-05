using Freelancer.Model.Common;
namespace Freelancer.Web.Areas.Admin.ViewModels.DataTable
{

    /// <summary>
    /// The parameters sent by jQuery DataTables in AJAX queries.
    /// </summary>
    public class DTParameters
    {
        public bool IsActive { get; set; }

        /// <summary>
        /// Draw counter.
        /// This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence).
        /// This is used as part of the draw return parameter (see below).
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// An array defining all columns in the table.
        /// </summary>
        public DTColumn[] Columns { get; set; }

        /// <summary>
        /// An array defining how many columns are being ordering upon - i.e. if the array length is 1, then a single column sort is being performed, otherwise a multi-column sort is being performed.
        /// </summary>
        public DTOrder[] Order { get; set; }

        /// <summary>
        /// Paging first record indicator.
        /// This is the start point in the current data set (0 index based - i.e. 0 is the first record).
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Number of records that the table can display in the current draw.
        /// It is expected that the number of records returned will be equal to this number, unless the server has fewer records to return.
        /// Note that this can be -1 to indicate that all records should be returned (although that negates any benefits of server-side processing!)
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Global search value. To be applied to all columns which have searchable as true.
        /// </summary>
        public DTSearch Search { get; set; }

        /// <summary>
        /// Custom column that is used to further sort on the first Order column.
        /// </summary>


        public string SortOrder
        {
            get
            {
                return Columns != null && Order != null && Order.Length > 0
                    ? (Columns[Order[0].Column].Data + (Order[0].Dir == DTOrderDir.DESC ? " " + Order[0].Dir : string.Empty))
                    : null;
            }
        }

        public string SortOrderColumnName
        {
            get
            {
                if (Columns != null && Order != null && Order.Length > 0)
                {
                    return Columns[Order[0].Column].Data;
                }

                return null;
            }
        }

        public DTOrderDir SortOrderDirection
        {
            get
            {
                if (Columns != null && Order != null && Order.Length > 0)
                {
                    return Order[0].Dir;
                }

                return DTOrderDir.ASC;
            }
        }



        public SearchParameters GetSearchParameters()
        {                          //Find Order Column

            //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            //var sortColumnDir = param.SortOrder;//Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var searchText = (Search != null) ? Search.Value : null;


            return new SearchParameters
            {

                SearchText = searchText,
                PageStart = Start,

                PageSize = Length,
                SortOrder = SortOrder,
                SortColumnName = SortOrderColumnName,
                SortOrderDescending = SortOrderDirection == DTOrderDir.DESC
            };

        }

    }

}