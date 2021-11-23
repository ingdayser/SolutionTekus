using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.Dto.In;
using Tekus.Core.Application.Helpers;

namespace Tekus.Core.Application.ServiceContracts
{
    public interface IServiceAppService
    {
        Task<RequestResult<ServiceDto>> CreateAsync(ServiceDto service);
        Task<ServiceDto> UpdateAsync(ServiceDto serviceDto);
        Task<ServiceDto> GetByIdAsync(Guid id);
        Task<RequestResult<List<ServiceDto>>> GetAllAsync();
        Task<bool> DeleteAsync();

    }
}
