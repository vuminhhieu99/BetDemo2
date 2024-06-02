using Bet.Bussiness.Interfaces;
using Bet.Bussiness.Version1;
using Bet.Data.Interfaces;
using Bet.Data.Version1;

namespace BetDemo.Extensions
{
    public static class DependencyInjection
    {
        // cấu hình Dependeny Injection
        public static IServiceCollection CustomDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IBaseBussiness<>), typeof(BaseBussiness<>));
            services.AddScoped(typeof(ITournamentBussiness), typeof(TournamentBussiness));
            services.AddScoped(typeof(IUserBussiness), typeof(UserBussiness));
            services.AddScoped(typeof(IAttachmentBussiness), typeof(AttachmentBussiness));

            services.AddScoped(typeof(IBaseData<>), typeof(BaseData<>));
            services.AddScoped(typeof(IUserData), typeof(UserData));

            return services;
        }

    }
}
