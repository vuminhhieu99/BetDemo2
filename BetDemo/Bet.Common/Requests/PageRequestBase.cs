using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Requests
{
    public class PageRequestBase
    {
        /// <summary>
        /// Trang số
        /// </summary>
        public int PageIndex { set; get; }

        /// <summary>
        /// số bản ghi/trang
        /// </summary>
        public int PageSize { set; get; }

        public PageRequestBase(int pageIndex = 1, int pageSize = 10)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
