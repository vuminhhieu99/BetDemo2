using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Results
{
    public class ErrorResult
    {
        /// <summary>
        /// thông báo lỗi tới develop
        /// </summary>
        public string? DevMsg { get; set; }

        /// <summary>
        /// thông báo lỗi tới người dùng
        /// </summary>
        public string? UserMsg { get; set; }

        /// <summary>
        /// code bị lỗi
        /// </summary>
        public string? ErrorCode { get; set; }

        /// <summary>
        /// thông tin thêm
        /// </summary>
        public string? MoreInfor { get; set; }

        /// <summary>
        /// todo...
        /// </summary>
        public string? TraceId { get; set; }

    }
}
