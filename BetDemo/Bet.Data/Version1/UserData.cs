using Bet.Common;
using Bet.Common.Entities.BO;
using Bet.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Data.Version1
{
    public class UserData : BaseData<User>, IUserData
    {
        IUnitOfWork _unitOfWork;
        public UserData(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Login(string userName, string passwordMd5)
        {
            string query = BetUtil.GetQuerySql("Login", "User");
            User user = _unitOfWork.QueryFirstOrDefault<User>(query, new {
                UserName = userName,
                PasswordMd5 = passwordMd5
            },150);
            return user;
        }
    }
    
}
