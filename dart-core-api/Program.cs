using dart_core_api;
using dart_core_api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.OpenApi;
using dart_core_api.Hubs;
using Ninject;
using dart_core_api.Ninject;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace dart_main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<DbContext>();
            builder.Services.AddDbContext<DiagnosticDbContext>();
            builder.Services.AddDbContext<MainDbContext>();
            builder.Services.ConfigureServices();
            builder.Services.AddSignalR();
            
           

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "TestCors",
                     builder =>
                     {
                         builder.WithOrigins("http://localhost:3000");
                     });
            });

            using (var diagnosticDatabase = new DiagnosticDbContext())
            {
                diagnosticDatabase.Database.EnsureCreated();
                diagnosticDatabase.Database.Migrate();
            }

            using (var mainDatabase = new MainDbContext())
            {
                mainDatabase.Database.EnsureCreated();
                mainDatabase.Database.Migrate();
            }

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.MapHub<ContainerHub>("/ContainerHub");

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
