using GlobCartOrderService.Services.API;
using GlobCartOrderService.Services.API.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(new[] { "https://www.minhaloja.com.br", "https://www.minhaloja.com.br" });
    });
});

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddAutoMapperConfig();

var app = builder.Build();

app.UseSwaggerSetup(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Use the .AllowAnyMethod().AllowAnyHeader().AllowCredentials() only to test localhost

//app.UseCors(options =>
//{
//    options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
//});

app.Run();
