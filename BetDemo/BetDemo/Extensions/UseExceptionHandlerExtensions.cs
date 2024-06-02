using Bet.Common.Enum;
using Bet.Common.Results;
using Microsoft.AspNetCore.Diagnostics;

namespace BetDemo.Extensions
{
    public static class UseExceptionHandlerExtensions
    {
        /// <summary>
        /// Đăng ký lỗi ngoại lệ của chương trình
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
                var errorResult = new List<ErrorResult>();
                errorResult.Add(new ErrorResult()
                {
                    DevMsg = exception.Message,
                    UserMsg = BetDemo.Properties.Resources.Error_Exeption,

                });

                var result = new ServiceResult()
                {
                    Data = null,
                    Error = errorResult,
                    Status = BetServiceCode.Exception

                };
                await context.Response.WriteAsJsonAsync(result);
            }));
        }
    }
}
