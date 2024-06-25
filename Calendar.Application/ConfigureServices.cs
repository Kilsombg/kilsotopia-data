using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Calendar.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicaitonServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });

            return services;
        }
    }
}
