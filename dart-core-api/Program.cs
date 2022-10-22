using dart_core_api;
using dart_core_api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.OpenApi;
using dart_core_api.Hubs;

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
            builder.Services.AddSignalR();

            using (var db = new DiagnosticDbContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapHub<TestHub>("/dart-testHub");

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
