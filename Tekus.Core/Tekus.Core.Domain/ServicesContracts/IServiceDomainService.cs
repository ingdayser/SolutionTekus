using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Domain.Entities;

namespace Tekus.Core.Domain.ServicesContracts
{
    public interface IServiceDomainService
    {
        Task<Service> CreateAsync(Service service);
        Task<Service> UpdateAsync(Service service);
        Task<Service> GetByIdAsync(Guid id);
        Task<List<Service>> GetAllAsync();
       
    }
}
