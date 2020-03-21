using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Framework.Utilities.Pagination
{
    public interface IPaginatedList
    {
        /// <summary>
        /// Gets the start range.
        /// </summary>
        /// <value>
        /// The start range.
        /// </value>
        int StartRange { get; }
        /// <summary>
        /// Gets the end range.
        /// </summary>
        /// <value>
        /// The end range.
        /// </value>
        int EndRange { get; }
        /// <summary>
        /// Gets the total item count.
        /// </summary>
        /// <value>
        /// The total item count.
        /// </value>
        int TotalItemCount { get; }
        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        int PageSize { get; }
    }
}
