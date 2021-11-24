using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Domain.Contracts;
using Tekus.Core.Domain.Entities;
using Tekus.Core.Domain.ServicesContracts;

namespace Tekus.Core.Domain.Services
{
    public class ServiceDomainService : IServiceDomainService
    {
        #region Fields

        private readonly ITekusRepository<Service> _serviceRepository;

        #endregion

        #region Builders

        public ServiceDomainService(ITekusRepository<Service> serviceRepository)
        {
            this._serviceRepository = serviceRepository;
        }

        #endregion

        #region Methods
        public async Task<Service> CreateAsync(Service service)
        {
            service.Id = Guid.NewGuid();
            service.CreaterAt = DateTime.Now;
            Service response = await _serviceRepository.InsertAsync(service);
            _serviceRepository.Save();
            return response;
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _serviceRepository.GetAllAsync();

        }

        public async Task<Service> GetByIdAsync(Guid id)
        {
            return await _serviceRepository.GetByIdAsync(id);
        }

        public Task<Service> UpdateAsync(Service service)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
