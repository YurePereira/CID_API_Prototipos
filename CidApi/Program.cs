using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using CidApi.Application.Services;
using CidApi.Domain.Interfaces;
using CidApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.EnvironmentName;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Registrar dependências:
builder.Services.AddScoped<ICidRepository, CidRepository>();
builder.Services.AddScoped<CidService>();

builder.Services.AddControllers();

//Adiciona suporte ao Swagger:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CID API",
        Version = "v1",
        Description = "API para consulta de CIDs",
        Contact = new OpenApiContact
        {
            Name = "Suporte API Yure",
            Email = "franciscoy@gmail.com",
            Url = new Uri("https://github.com/seu-repositorio")
        }
    });
});

var app = builder.Build();

//Ativa o Swagger apenas nos ambientes de Development e Training:
if (app.Environment.IsDevelopment() || environment == "Training")
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CID API v1");
        c.RoutePrefix = string.Empty; // Deixa o Swagger na raiz (`http://localhost:5000`)
    });
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
