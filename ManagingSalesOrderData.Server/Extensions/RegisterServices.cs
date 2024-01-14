using ManagingSalesOrderData.BLL.Interfaces;
using ManagingSalesOrderData.BLL.Services;

namespace ManagingSalesOrderData.Server.Extensions
{
    public static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubElementService, SubElementService>();
            services.AddScoped<IWindowService, WindowService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
