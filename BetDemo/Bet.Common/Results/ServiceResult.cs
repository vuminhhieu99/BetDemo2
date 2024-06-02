using Bet.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Results
{
    public class ServiceResult
    {
        /// <summary>
        /// dữ liệu trả về
        /// </summary>
        public object? Data { get; set; }
        /// <summary>
        /// thông tin lỗi
        /// </summary>
        public List<ErrorResult> Error { get; set; }

        /// <summary>
        /// Mã kết quả
        /// </summary>
        public BetServiceCode Status { get; set; }
        public ServiceResult()
        {
            Error = new List<ErrorResult>();
            Status = BetServiceCode.Success;
        }

        /// <summary>
        /// Trả về lỗi chương trình
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="userMsg"></param>
        /// <returns></returns>
        public static ServiceResult ExceptionCustom(Exception ex, string userMsg) {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Error = new List<ErrorResult>() {
                    new ErrorResult() {
                        DevMsg = ex.Message,
                        UserMsg = userMsg
                    }
                };
            serviceResult.Status = BetServiceCode.Exception;
            return serviceResult;
        }
    }
}
