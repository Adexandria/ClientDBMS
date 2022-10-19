using ClientDBMS.Services;
using ClientDBMS.Services.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SessionFactory>();
builder.Services.AddSingleton<AppConfiguration>();
builder.Services.AddScoped<IClient, ClientRepository>();
builder.Services.AddDbContext<ClientDbContext>(s => { s.UseSqlServer(config.GetConnectionString("DefaultConnection")); });
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(s=>s.RoutePrefix = string.Empty);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
