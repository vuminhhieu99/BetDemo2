using Bet.Common;
using System.IdentityModel.Tokens.Jwt;

namespace BetDemo.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleResponseMiddleware>()
                .UseMiddleware<CachingMiddleware>();
        }
        // Hoàn toàn có thể taoj ra 1 middleware theo cách này ExtraMiddleware sẽ được thực thi sau các middleware đã được đăng kyus trước nó
        //public static IApplicationBuilder ExtraCustomMiddleware(this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<ExtraMiddleware>();

        //}

    }

    public class SimpleResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                this.attachUserToContext(context);
            }
            await _next(context);
        }

        /// <summary>
        /// Lấy 1 số dữ liệu từ token
        /// </summary>
        private void attachUserToContext(HttpContext context)
        {
            try
            {
                if(context.User.Claims.Count() > 0)
                {                    
                    int userId = int.Parse(context.User.Claims.First(c => c.Type == CommonKey.sessionUserId).Value);
                    string userName = context.User.Claims.First(c => c.Type == CommonKey.sessionUserName).Value.ToString();
                }
               
            }
            catch
            {
                ;
            }

        }
    }

    // Đây là middleware thứ 2 nếu muốn thêm nhiều middeware bap gồm nội dung caching
    public class CachingMiddleware
    {
        private readonly RequestDelegate _next;

        public CachingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // todo            
            await _next(context);
        }

    }
}
