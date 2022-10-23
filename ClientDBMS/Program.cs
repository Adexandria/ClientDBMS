using ClientDBMS.Services;
using ClientDBMS.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.IsDevelopment() ? "Development" : "Production";
var config = new ConfigurationBuilder().AddJsonFile($"appsettings.{env}.json", false, reloadOnChange: true).Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SessionFactory>();
builder.Services.AddSingleton<AppConfiguration>();
builder.Services.AddScoped<IClient, ClientRepository>();
builder.Services.AddDbContext<ClientDbContext>(s => { s.UseSqlServer(config.GetConnectionString("DefaultConnection")); });
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CLientDBMS API",
        Description = "An ASP.NET Core Web API for managing clients"
    });
});
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(s=> {
        s.RoutePrefix = string.Empty;
        s.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
    }
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
