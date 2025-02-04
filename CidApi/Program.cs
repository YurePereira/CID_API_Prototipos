using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using CidApi.Infrastructure.Data;
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

//Configurar conexão com SQL Server:
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CidDbContext>(options => options.UseSqlServer(connectionString));

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
            Email = "franciscoyurep@gmail.com",
            Url = new Uri("https://github.com/YurePereira/CID_API_Prototipos")
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
        c.RoutePrefix = string.Empty;//Deixa o Swagger na raiz (`http://localhost:5000`)
    });
}

//Aplicar migrações automaticamente ao iniciar o app:
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CidDbContext>();
    dbContext.Database.Migrate();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
