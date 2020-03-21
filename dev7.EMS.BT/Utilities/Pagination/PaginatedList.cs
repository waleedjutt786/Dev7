using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Framework.Utilities.Pagination
{
    public class PaginatedList<T> : IPaginatedList
    {
        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public PaginatedList(IQueryable<T> list, int? page = null, int? pageSize = null)
        {
            _list = list;
            _page = page;
            _pageSize = pageSize;
        }

        #endregion ctor

        #region fields

        private readonly IQueryable<T> _list;
        private readonly int? _page;
        private int? _pageSize;

        #endregion fields

        #region properties

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IQueryable<T> Items => _list?.Skip((Page - 1) * PageSize).Take(PageSize);

        public int Page => _page ?? 1;

        public int PageSize
        {
            get
            {
                if (!_pageSize.HasValue)
                {
                    return _list?.Count() ?? 0;
                }
                return _pageSize.Value;
            }
        }

        /// <summary>
        /// Gets the total item count.
        /// </summary>
        /// <value>
        /// The total item count.
        /// </value>
        public int TotalItemCount => _list?.Count() ?? 0;

        public int StartRange
        {
            get
            {
                if (Page <= 1 && TotalItemCount == 0)
                    return 0;
                return Page <= 1 ? 1 : Page * PageSize - (PageSize - 1);
            }
        }

        /// <summary>
        /// Gets the end range.
        /// </summary>
        /// <value>
        /// The end range.
        /// </value>
        public int EndRange
        {
            get
            {
                if (Page <= 1)
                {
                    return TotalItemCount <= PageSize ? TotalItemCount : PageSize;
                }
                var result = Page * PageSize;
                return result < TotalItemCount ? result : TotalItemCount;
            }
        }

        #endregion properties
    }
}
