using ManagingSalesOrderData.DAL.Interfaces;
using ManagingSalesOrderData.DAL.Repositories;

namespace ManagingSalesOrderData.Server.Extensions
{
    public static class RegisterRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISubElementRepository, SubElementRepository>();
            services.AddScoped<IWindowRepository, WindowRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
