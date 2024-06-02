using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Enum
{
    public enum BetServiceCode
    {
        /// <summary>
        /// Lỗi dữ liệu không hợp lệ
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Lỗi ngoại lệ
        /// </summary>
        Exception = 500,

        /// <summary>
        /// Lỗi lấy về thấy bại
        /// </summary>
        Fail = 0

    }
}
