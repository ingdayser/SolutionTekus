using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Domain.Entities;

namespace Tekus.Core.Domain.ServicesContracts
{
    public interface IProviderDomainService
    {
        Task<Provider> CreateAsync(Provider provider);
        Task<Provider> UpdateAsync(Provider provider);
        Task<Provider> GetByIdAsync(Guid id);
        Task<List<Provider>> GetAllAsync();
       
    }
}
