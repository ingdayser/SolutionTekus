using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Domain.Contracts;
using Tekus.Core.Domain.Entities;
using Tekus.Core.Domain.ServicesContracts;

namespace Tekus.Core.Domain.Services
{
    public class ProviderDomainService : IProviderDomainService
    {
        #region Fields

        private readonly ITekusRepository<Provider> _providerRepository;

        #endregion

        #region Builders

        public ProviderDomainService(ITekusRepository<Provider> providerRepository)
        {
            this._providerRepository = providerRepository;
        }

        #endregion

        #region Methods

        public async Task<Provider> CreateAsync(Provider provider)
        {            
            provider.CreatedAt = DateTime.Now;
            Provider response = await _providerRepository.InsertAsync(provider);
            _providerRepository.Save();
            return response;
        }

        public async Task<List<Provider>> GetAllAsync()
        {
            return await _providerRepository.GetAllAsync();

        }

        public async Task<Provider> GetByIdAsync(Guid id)
        {
            return await _providerRepository.GetByIdAsync(id);
        }

        public Task<Provider> UpdateAsync(Provider provider)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
