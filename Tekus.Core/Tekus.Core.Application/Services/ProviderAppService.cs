using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.DTO.In;
using Tekus.Core.Application.Helpers;
using Tekus.Core.Application.ServicesContracts;
using Tekus.Core.Domain.Entities;
using Tekus.Core.Domain.ServicesContracts;

namespace Tekus.Core.Application.Services
{
    public class ProviderAppService : IProviderAppService
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IProviderDomainService _providerDomain;

        #endregion

        #region Builders

        public ProviderAppService(IProviderDomainService providerDomainProvider, IMapper mapper)
        {
            this._providerDomain = providerDomainProvider;
            this._mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<RequestResult<ProviderDto>> CreateAsync(ProviderDto providerDto)
        {
            try
            {
                if (providerDto is null) return RequestResult<ProviderDto>.CreateUnsuccessful(new string[] { "Se requiere suministrar data para este consumo Provider/Create"});
               
                Provider provider = await _providerDomain.CreateAsync(BuilderProvider(providerDto));
                if (provider is not null)
                {
                    return RequestResult<ProviderDto>.CreateSuccessful(_mapper.Map<ProviderDto>(provider));
                }
                else
                {
                    return RequestResult<ProviderDto>.CreateUnsuccessful(null);
                }
            }
            catch (Exception ex)
            {
                return RequestResult<ProviderDto>.CreateError(ex);
            }           
        }

        public async Task<RequestResult<List<ProviderDto>>> GetAllAsync()
        {
            try
            {
                List<Provider> services = await _providerDomain.GetAllAsync();
                var servicesDto = _mapper.Map<List<ProviderDto>>(services);
                return RequestResult<List<ProviderDto>>.CreateSuccessful(servicesDto);
            }
            catch (Exception ex)
            {
                return RequestResult<List<ProviderDto>>.CreateError(ex);
            }
        }

        public async Task<RequestResult<ProviderDto>> GetByIdAsync(Guid id)
        {
            try
            {
                Provider service = await _providerDomain.GetByIdAsync(id);
                if (service is not null)
                {
                    return RequestResult<ProviderDto>.CreateSuccessful(_mapper.Map<ProviderDto>(service));
                }
                else
                {
                    return RequestResult<ProviderDto>.CreateUnsuccessful(null);
                }
            }
            catch (Exception ex)
            {
                return RequestResult<ProviderDto>.CreateError(ex);
            }
        }

        public Task<ProviderDto> UpdateAsync(ProviderDto providerDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MethodsPrivate

        private Provider BuilderProvider(ProviderDto providerDto)
        {
            Provider provider = _mapper.Map<Provider>(providerDto);
            provider.Id= Guid.NewGuid();  
            if (providerDto.AttributesProvider.Count>0)
            {
                foreach (AttributeDto item in providerDto.AttributesProvider)
                {
                    CustomAttribute attribute = _mapper.Map<CustomAttribute>(item);
                    attribute.Id = Guid.NewGuid();
                    attribute.Provider = provider.Id;
                    provider.CustomAttributes.Add(attribute);
                } 
            }
            return provider;
        }

        #endregion

    }
}
