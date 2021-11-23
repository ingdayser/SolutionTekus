using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Domain.Entities;

namespace Tekus.Core.Domain.ServiceContracts
{
    public interface ICountryDomainService
    {       
        Task<Country> GetByIdAsync(string id);
        Task<List<Country>> GetAllAsync();        
    }
}
