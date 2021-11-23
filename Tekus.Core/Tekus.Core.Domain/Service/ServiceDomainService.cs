using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Domain.Contracts;
using Tekus.Core.Domain.Entities;
using Tekus.Core.Domain.ServiceContracts;

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
        public Task<Service> CreateAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _serviceRepository.GetAll();

        }

        public Task<Service> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Service> UpdateAsync(Service service)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
