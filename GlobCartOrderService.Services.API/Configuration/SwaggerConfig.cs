using Microsoft.OpenApi.Models;

namespace GlobCartOrderService.Services.API
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GlobCart Service",
                    Description = "GlobCart Service API",
                    Contact = new OpenApiContact { Name = "Filippo", Email = "filippo.maniaci.work@gmail.com" }
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
        }
    }
}
