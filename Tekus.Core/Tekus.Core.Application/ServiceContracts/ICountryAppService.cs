using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.DTO.Out;
using Tekus.Core.Application.Helpers;

namespace Tekus.Core.Application.ServiceContracts
{
    public interface ICountryAppService
    {  
        Task<RequestResult<CountryDto>> GetByIdAsync(string id);
        Task<RequestResult<List<CountryDto>>> GetAllAsync();
    }
}
