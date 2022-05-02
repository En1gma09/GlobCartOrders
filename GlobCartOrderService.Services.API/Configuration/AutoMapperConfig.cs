using GlobCartOrderService.Services.API.Configuration.AutoMapper;

namespace GlobCartOrderService.Services.API.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
