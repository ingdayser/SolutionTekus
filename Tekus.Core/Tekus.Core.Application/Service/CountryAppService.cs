using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.DTO.Out;
using Tekus.Core.Application.Helpers;
using Tekus.Core.Application.ServiceContracts;
using Tekus.Core.Domain.Entities;
using Tekus.Core.Domain.ServiceContracts;

namespace Tekus.Core.Application.Services
{
    public class CountryAppService : ICountryAppService
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly ICountryDomainService _countryDomain;

        #endregion

        #region Builders

        public CountryAppService(ICountryDomainService countryDomainService, IMapper mapper)
        {
            this._countryDomain = countryDomainService;
            this._mapper = mapper;
        }

        #endregion

     

        public async Task<RequestResult<List<CountryDto>>> GetAllAsync()
        {
            try
            {
                List<Country> countries = await _countryDomain.GetAllAsync();
                var countriesDto = _mapper.Map<List<CountryDto>>(countries);
                return RequestResult<List<CountryDto>>.CreateSuccessful(countriesDto);
            }
            catch (Exception ex)
            {
                return RequestResult<List<CountryDto>>.CreateError(ex);
            }
        }

        public async Task<RequestResult<CountryDto>> GetByIdAsync(string id)
        {
            try
            {
                Country country = await _countryDomain.GetByIdAsync(id);
                var countryDto = _mapper.Map<CountryDto>(country);
                return RequestResult<CountryDto>.CreateSuccessful(countryDto);
            }
            catch (Exception ex)
            {
                return RequestResult<CountryDto>.CreateError(ex);
            }
        }

     
    }
}
