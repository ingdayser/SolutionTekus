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
    public class ServiceAppService : IServiceAppService
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IServiceDomainService _servicesDomain;

        #endregion

        #region Builders

        public ServiceAppService(IServiceDomainService servicesDomainService, IMapper mapper)
        {
            this._servicesDomain = servicesDomainService;
            this._mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<RequestResult<ServiceDto>> CreateAsync(ServiceDto serviceDto)
        {
            try
            {
                if (serviceDto is null) return RequestResult<ServiceDto>.CreateUnsuccessful(new string[] { "Se requiere suministrar data para este consumo Service/Create"});
                Service service = await _servicesDomain.CreateAsync(_mapper.Map<Service>(serviceDto));
                if (service is not null)
                {
                    return RequestResult<ServiceDto>.CreateSuccessful(_mapper.Map<ServiceDto>(service));
                }
                else
                {
                    return RequestResult<ServiceDto>.CreateUnsuccessful(null);
                }
            }
            catch (Exception ex)
            {
                return RequestResult<ServiceDto>.CreateError(ex);
            }           
        }

        public async Task<RequestResult<List<ServiceDto>>> GetAllAsync()
        {
            try
            {
                List<Service> services = await _servicesDomain.GetAllAsync();
                var servicesDto = _mapper.Map<List<ServiceDto>>(services);
                return RequestResult<List<ServiceDto>>.CreateSuccessful(servicesDto);
            }
            catch (Exception ex)
            {
                return RequestResult<List<ServiceDto>>.CreateError(ex);
            }
        }

        public async Task<RequestResult<ServiceDto>> GetByIdAsync(Guid id)
        {
            try
            {
                Service service = await _servicesDomain.GetByIdAsync(id);
                if (service is not null)
                {
                    return RequestResult<ServiceDto>.CreateSuccessful(_mapper.Map<ServiceDto>(service));
                }
                else
                {
                    return RequestResult<ServiceDto>.CreateUnsuccessful(null);
                }
            }
            catch (Exception ex)
            {
                return RequestResult<ServiceDto>.CreateError(ex);
            }
        }

        public Task<ServiceDto> UpdateAsync(ServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
