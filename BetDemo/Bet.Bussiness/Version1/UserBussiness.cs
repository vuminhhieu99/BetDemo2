using Bet.Bussiness.Interfaces;
using Bet.Common;
using Bet.Common.Entities.BO;
using Bet.Common.Results;
using Bet.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Bussiness.Version1
{
    public class UserBussiness : BaseBussiness<User>, IUserBussiness
    {

        private IUserData _userData;
        public IConfiguration _configuration;

        public UserBussiness(IBaseData<User> baseData, IConfiguration configuration, IUserData userData) : base(baseData)
        {
            _configuration = configuration;
            _userData = userData;
        }

        /// <summary>
        /// Đăng nhập hệ thống
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ServiceResult Login(string userName, string password)
        {
            ServiceResult serviceResult = new ServiceResult();

            string passwordMd5 = BetUtil.CreateMD5(password);

            var user = this._userData.Login(userName, passwordMd5);
            if (user != null)
            {
                AuthenticateResponse data = new AuthenticateResponse();
                data = JsonConvert.DeserializeObject<AuthenticateResponse>(JsonConvert.SerializeObject(user));
                data.Token = GenerateJSONWebToken(user);
                data.RefreshToken = GenerateRefreshToken();
                _ = int.TryParse(_configuration["Jwt:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                data.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDays);
                serviceResult.Data = data;
                user.RefreshToken = data.RefreshToken;
                user.RefreshTokenExpiryTime = data.RefreshTokenExpiryTime;
                _userData.UpdateAsync(user, "RefreshToken,RefreshTokenExpiryTime");
            }
            else
            {
                serviceResult.Status = Common.Enum.BetServiceCode.Fail;
            }
            return serviceResult;
        }


        /// <summary>
        /// Tạo mã token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(User? userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(CommonKey.sessionUserId, userInfo.Id.ToString()),
                new Claim(CommonKey.sessionUserName, userInfo.UserName),
                new Claim(CommonKey.sessionEmail, userInfo.Email),
                new Claim("DateOfJoing", userInfo.CreatedDate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(Double.Parse(_configuration["Jwt:TokenValidityInMinutes"].ToString())),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Tạo mã refresh token
        /// </summary>
        /// <returns></returns>
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        /// <summary>
        /// Refresh lại giá trị
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task<ServiceResult> RefreshToken(string? refreshToken)
        {
            ServiceResult serviceResult = new ServiceResult();
            string? accessToken = SessionData.Instance.Token;
            int? userId = SessionData.Instance.UserId;
            if (string.IsNullOrWhiteSpace(refreshToken) || accessToken is null || userId is null )
            {
                serviceResult.Status = Common.Enum.BetServiceCode.BadRequest;
                return serviceResult;
            }

            var user = await _userData.GetByIdAsync(userId);
            if (user is null || user.RefreshToken != refreshToken)
            {
                serviceResult.Status = Common.Enum.BetServiceCode.BadRequest;
                serviceResult.Error = new List<ErrorResult> {
                    new ErrorResult() {
                        DevMsg = "Không tìn thấy người dùng"
                    }
                };
                return serviceResult;
            }           
            if (user != null && user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                serviceResult.Status = Common.Enum.BetServiceCode.BadRequest;
                serviceResult.Error = new List<ErrorResult> { 
                    new ErrorResult() {
                        DevMsg = "RefreshToke đã hết hạn"
                    } 
                };
                return serviceResult;            
            }

            string? newAccessToken = GenerateJSONWebToken(user);
            Dictionary<string, string> newProperties = new Dictionary<string, string>()
            {
                { "token" , newAccessToken},                
            };
            serviceResult.Data = newProperties;
            return serviceResult;
        }


    }
}
