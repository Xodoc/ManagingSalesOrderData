using ManagingSalesOrderData.BLL.Interfaces;
using ManagingSalesOrderData.BLL.Validators;

namespace ManagingSalesOrderData.Server.Extensions
{
    public static class RegisterValidators
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator, Validator>();

            return services;
        }
    }
}
