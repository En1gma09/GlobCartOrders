using GlobCartOrderService.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GlobCartOrderService.Services.API.Configuration
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GlobCartOrderServiceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
