using Microsoft.AspNetCore.Mvc.Razor;

namespace BetDemo.Extensions
{
    public static class LocalizationExtensions
    {
        public static IServiceCollection CustomLocalization(this IServiceCollection services)
        {           
            services.AddLocalization(options => options.ResourcesPath = "");

            services.AddControllersWithViews()
                .AddViewLocalization
                (LanguageViewLocationExpanderFormat.SubFolder)
                .AddDataAnnotationsLocalization();


            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "vi-VN", "en-US" };
                options.SetDefaultCulture(supportedCultures[1])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });

            return services;

        }

        public static IApplicationBuilder CustomUseRequestLocalization(this IApplicationBuilder builder)
        {
            var supportedCultures = new[] { "vi-VN", "en-US" };

            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[1])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            // Cấu hình chỉ địnhlocalization trên header api với Accept-Language = supportedCultures
            // ưu tiên sử dụng cookie để lưu
            //localizationOptions.ApplyCurrentCultureToResponseHeaders =  true; 

            return builder.UseRequestLocalization(localizationOptions);
        }
    }
}
