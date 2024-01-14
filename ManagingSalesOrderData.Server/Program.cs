using ManagingSalesOrderData.DAL.Database;
using ManagingSalesOrderData.Server.Extensions;
using ManagingSalesOrderData.Server.Middleware;
using Microsoft.EntityFrameworkCore;
using static ManagingSalesOrderData.Shared.Constants.ConfigurationConstants;

namespace ManagingSalesOrderData.Server
{
    public class Program
    {
        private static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            PrepDb.SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>(), isProd);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString(CONNECTION_STRING);

            if (builder.Environment.IsProduction())
            {
                Console.WriteLine("--> Using SqlServer db");
                builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
            }
            else
            {
                Console.WriteLine("--> Using InMem db");
                builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
            }

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRepositories().AddValidators().AddServices();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseWebAssemblyDebugging();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            PrepPopulation(app, app.Environment.IsProduction());

            app.Run();
        }
    }
}