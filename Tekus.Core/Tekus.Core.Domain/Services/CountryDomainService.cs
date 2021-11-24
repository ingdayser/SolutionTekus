using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tekus.Core.Domain.Contrats;
using Tekus.Core.Domain.Entities;
using Tekus.Core.Domain.Entities.Config;
using Tekus.Core.Domain.ServicesContracts;

namespace Tekus.Core.Domain.Services
{
    public class CountryDomainService : ICountryDomainService
    {
        #region Fields

        private readonly IGenericServiceAgent _genericServiceAgent;
        private readonly RestCountriesSettings _restCountriesSettings;

        #endregion

        #region Builders

        public CountryDomainService(IGenericServiceAgent genericServiceAgent, IOptions<RestCountriesSettings> restSettings)
        {
            this._genericServiceAgent = genericServiceAgent;
            this._restCountriesSettings = restSettings.Value;
        }

        #endregion

        #region Methods
  

        public async Task<List<Country>> GetAllAsync()
        {
            return await _genericServiceAgent.GetAsync<List<Country>>(_restCountriesSettings.BaseUrl+Strings.Url_AllCountries);

        }

        public async Task<Country> GetByIdAsync(string id)
        {
            var response= await _genericServiceAgent.GetAsync<List<Country>>(_restCountriesSettings.BaseUrl + Strings.Url_CountryByCioc(id));
            return response.FirstOrDefault();
        }

     

        #endregion
    }
}
