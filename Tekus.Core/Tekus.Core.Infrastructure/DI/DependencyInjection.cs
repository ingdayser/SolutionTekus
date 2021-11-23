using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tekus.Core.Domain.Contracts;
using Tekus.Core.Domain.Entities.Config;
using Tekus.Core.Domain.ServiceAgentContrats;
using Tekus.Core.Infrastructure.DataAccess;
using Tekus.Core.Infrastructure.ServiceAgent;

namespace Tekus.Core.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TekusDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TekusConnectionString"));
            });
            services.AddScoped(typeof(ITekusRepository<>), typeof(TekusRepository<>));
            services.AddScoped<IGenericServiceAgent, GenericServiceAgent>();

            services.Configure<RestCountriesSettings>(options => configuration.GetSection("RestCountriesSettings").Bind(options));
            return services;
        }
    }
}
