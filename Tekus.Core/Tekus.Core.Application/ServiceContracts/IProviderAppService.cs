using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.DTO.In;
using Tekus.Core.Application.Helpers;

namespace Tekus.Core.Application.ServicesContracts
{
    public interface IProviderAppService
    {
        Task<RequestResult<ProviderDto>> CreateAsync(ProviderDto providerDto);
        Task<ProviderDto> UpdateAsync(ProviderDto providerDto);
        Task<RequestResult<ProviderDto>> GetByIdAsync(Guid id);
        Task<RequestResult<List<ProviderDto>>> GetAllAsync();       

    }
}
