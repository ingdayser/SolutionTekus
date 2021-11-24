using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.DTO.In;
using Tekus.Core.Application.Helpers;

namespace Tekus.Core.Application.ServicesContracts
{
    public interface IServiceAppService
    {
        Task<RequestResult<ServiceDto>> CreateAsync(ServiceDto service);
        Task<ServiceDto> UpdateAsync(ServiceDto serviceDto);
        Task<RequestResult<ServiceDto>> GetByIdAsync(Guid id);
        Task<RequestResult<List<ServiceDto>>> GetAllAsync();
       

    }
}
