using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Results
{
    public class PageResult<T>
    {
        /// <summary>
        /// Danh sách trả về
        /// </summary>
        public IEnumerable<T> Items { set; get; } = Enumerable.Empty<T>();

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecord { get; set; }
    }
}
