using Microsoft.Extensions.DependencyInjection;
using Tekus.Core.Domain.Services;
using Tekus.Core.Domain.ServicesContracts;

namespace Tekus.Core.Domain.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ICountryDomainService, CountryDomainService>();
            services.AddScoped<IServiceDomainService, ServiceDomainService>();
            services.AddScoped<IProviderDomainService, ProviderDomainService>();
            return services;
        }
    }
}
