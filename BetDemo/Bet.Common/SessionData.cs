using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Bet.Common
{
    public class SessionData : ISessionData
    {

        public static IHttpContextAccessor? _accessor;

        private static readonly object _lock = new object();

        private static volatile ISessionData? _instance;
        // sử dụng singleton
        public static ISessionData Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SessionData();
                        }
                    }
                }
                return _instance;
            }
        }

        public void contructorHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;

        }
        public ClaimsPrincipal CurrentPrincipal
        {
            get
            {              
               return _accessor.HttpContext.User;                
            } 
        }
        public IHeaderDictionary Header
        {
            get
            {
                return _accessor.HttpContext.Request.Headers;
            }
        }
        /// <summary>
        /// Lấy id người dùng đang đăng nhập
        /// </summary>
        public int? UserId
        {
            get
            {
                int userId;
                try {
                    if (int.TryParse(CurrentPrincipal.Claims.First(c => c.Type == CommonKey.sessionUserId).Value, out userId))
                    {
                        return userId;
                    }
                    return null;
                }
                catch(Exception ex) {
                    LogCustom.LogError(ex, BetUtil.GetLogConfig("userid_fail"));
                    return null;
                }                        
                
            }
        }

        public string? UserName
        {
            get
            {
                try
                {
                    return CurrentPrincipal.Claims.First(c => c.Type == CommonKey.sessionUserName).Value;
                }
                catch(Exception ex)
                {
                    LogCustom.LogError(ex, BetUtil.GetLogConfig("username_fail"));
                    return null;
                }
            }
        }
        public string? LayoutCode
        {
            get
            {
                try
                {
                    return this.Header["LayoutCode"];
                }
                catch(Exception ex)
                {
                    LogCustom.LogError(ex, BetUtil.GetLogConfig("username_layoutcode"));
                    return null;
                }
            }
        }

        public string? Token
        {
            get
            {
                try
                {
                    return this.Header["Authorization"];
                }
                catch (Exception ex)
                {
                    LogCustom.LogError(ex, BetUtil.GetLogConfig("Username_Token"));
                    return null;
                }
            }
        }
    }
        
}
