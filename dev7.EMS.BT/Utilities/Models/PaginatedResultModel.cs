using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.Framework.Utilities.Pagination;

namespace dev7.EMS.Framework.Model
{
    public class PaginatedResultModel 
    {
        #region properties

        public int ShowingStartRange { get; set; }
        public int ShowingEndRange { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int LastPage { get; set; }

        public string ResultString => ShowingEndRange < PageSize
            ? $"Showing {ShowingStartRange} of {TotalRecords} records"
            : $"Showing {ShowingStartRange} - {ShowingEndRange} of {TotalRecords} records";

        #endregion properties

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResultModel"/> class.
        /// </summary>
        /// <param name="paginatedList">The paginated list.</param>
        public PaginatedResultModel(IPaginatedList paginatedList)
        {
            ShowingStartRange = paginatedList.StartRange;
            ShowingEndRange = paginatedList.EndRange;
            TotalRecords = paginatedList.TotalItemCount;
            PageSize = paginatedList.PageSize;
            LastPage = (TotalRecords + PageSize - 1) / PageSize;
        }

        public PaginatedResultModel()
        {
        }

        #endregion ctor
    }
}
