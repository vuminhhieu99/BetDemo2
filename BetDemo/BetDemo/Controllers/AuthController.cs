using Bet.Bussiness.Interfaces;
using Bet.Common;
using Bet.Common.Entities.BO;
using Bet.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Bet.Common.Enum;
using Bet.Common.Requests;

namespace BetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public IUserBussiness _userBussiness;
        public AuthController(IConfiguration config, IUserBussiness userBussiness)
        {
            _config = config;
            _userBussiness = userBussiness;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ServiceResult Login([FromBody] LoginRequest loginRequest)
        {
            try
             {
                ServiceResult serviceResult = new ServiceResult();
                serviceResult = _userBussiness.Login(loginRequest.UserName, loginRequest.Password);
                return serviceResult;
            }
            catch (Exception ex)
            {
                LogCustom.LogError(ex, "Login");
                return ServiceResult.ExceptionCustom(ex, BetUtil.GetLogConfig("user_login_fail"));
            }
        }
        [HttpGet]
        [Route("refresh-token")]
        public async Task<ServiceResult> RefreshToken(string? refreshToken)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult = await _userBussiness.RefreshToken(refreshToken);
            return serviceResult;           
        }


      

    }
}
