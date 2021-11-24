using Microsoft.Extensions.DependencyInjection;
using Tekus.Core.Application.Services;
using Tekus.Core.Application.ServicesContracts;

namespace Tekus.Core.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {       
            services.AddScoped<ICountryAppService, CountryAppService>();
            services.AddScoped<IServiceAppService, ServiceAppService>();
            services.AddScoped<IProviderAppService, ProviderAppService>();

            return services;
        }
    }
}
