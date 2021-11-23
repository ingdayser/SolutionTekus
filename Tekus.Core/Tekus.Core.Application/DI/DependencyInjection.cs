using Microsoft.Extensions.DependencyInjection;
using Tekus.Core.Application.ServiceContracts;
using Tekus.Core.Application.Services;

namespace Tekus.Core.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {       
            services.AddScoped<ICountryAppService, CountryAppService>();
            return services;
        }
    }
}
