using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Api.Application.UseCases;
using Api.Application.Validators;
using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Api.Infrastructure.Persistence.Repositories;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration["Swagger:Title"] ?? "Mottu API",
                    Description = "CP2",
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //swagger.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddDbContext < MotosContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleMottu"))
                    .UseLazyLoadingProxies();
            });
            
            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            builder.Services.AddScoped<IRepository<Moto>, Repository<Moto>>();
            
            builder.Services.AddScoped<CreateUserRequestValidator>();
            builder.Services.AddScoped<CreateMotoRequestValidator>();
            
            builder.Services.AddScoped<UserUseCase>();
            builder.Services.AddScoped<MotoUseCase>();

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}