using Microsoft.Extensions.DependencyInjection;
using Tekus.Core.Domain.ServiceAgentContrats;
using Tekus.Core.Domain.ServiceContracts;
using Tekus.Core.Domain.Services;

namespace Tekus.Core.Domain.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ICountryDomainService, CountryDomainService>();
         
            return services;
        }
    }
}
