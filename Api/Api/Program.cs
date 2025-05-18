using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Api.Application.Validators;
using Api.Application.UseCases;
using Api.Infrastructure.Context;
using Api.Infrastructure.Persistence.Repositories;
using Api.Domain.Entity;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços de controllers
builder.Services.AddControllers();

// Adiciona o Swagger com comentários XML (opcional, mas recomendado)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["Swagger:Title"] ?? "Mottu API",
        Description = "CP2 e Challenger",
        Version = "1.0",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seu@email.com"
        }
    });

    // Para incluir comentários XML (se ativado no .csproj)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// CONFIGURAÇÃO DE BANCO DE DADOS
// Você pode usar SQL Server, SQLite, Oracle, etc.
// Aqui usamos SQLite como exemplo genérico. Altere para seu caso real.
builder.Services.AddDbContext<MotosContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseLazyLoadingProxies());

builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseLazyLoadingProxies());

// REGISTRO DE VALIDATORS
builder.Services.AddScoped<CreateMotoRequestValidator>();
builder.Services.AddScoped<CreateUserRequestValidator>();

// OPCIONAL: Use Cases ou Repositórios
builder.Services.AddScoped<UserUseCase>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// BUILD
var app = builder.Build();

// CONFIGURAÇÃO DO PIPELINE
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();