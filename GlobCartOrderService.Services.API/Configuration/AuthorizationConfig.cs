namespace GlobCartOrderService.Services.API.Configuration
{
    public static class AuthorizationConfig
    {
        public static void AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Admin");
                    });
            });
        }
    }
}
