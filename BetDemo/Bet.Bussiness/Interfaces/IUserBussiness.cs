using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bet.Common.Entities.BO;
using Bet.Common.Results;

namespace Bet.Bussiness.Interfaces
{
    public interface IUserBussiness: IBaseBussiness<User>
    {
        /// <summary>
        /// Đăng nhập người dùng
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ServiceResult Login(string userName, string password);
        /// <summary>
        /// refresh lại tokken
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<ServiceResult> RefreshToken(string? refreshToken);
    }
}
