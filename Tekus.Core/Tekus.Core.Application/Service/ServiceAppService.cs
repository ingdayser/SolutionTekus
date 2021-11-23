using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.Dto.In;
using Tekus.Core.Application.Helpers;
using Tekus.Core.Application.ServiceContracts;
using Tekus.Core.Domain.Entities;
using Tekus.Core.Domain.ServiceContracts;

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

        public Task<RequestResult<ServiceDto>> CreateAsync(ServiceDto serviceDto)
        {
            try
            {
                Service service = _mapper.Map<Service>(serviceDto);
                service.Id = new Guid();
                _servicesDomain.CreateAsync(service);

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
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

        public Task<ServiceDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDto> UpdateAsync(ServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }
    }
}
