using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Services;
using GlobCartOrderService.Infra.Data.Context;
using GlobCartOrderService.Infra.Data.Repository;
using GlobCartOrderService.Services.API.Services;
using Microsoft.EntityFrameworkCore;

namespace GlobCartOrderService.Services.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<DbContext, GlobCartOrderServiceContext>();

        }
    }
}
