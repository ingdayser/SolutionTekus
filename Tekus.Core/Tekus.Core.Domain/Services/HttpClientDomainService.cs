using System.Net.Http;
using System.Threading.Tasks;
using Tekus.Core.Domain.Contrats;

namespace Tekus.Core.Domain.Services

{
    public class HttpClientDomainService : IHttpClientDomainService
    {
        #region Fields
        private readonly System.Net.Http.HttpClient _client;
        #endregion 

        #region Builder
        public HttpClientDomainService()
        {
            _client = new System.Net.Http.HttpClient();
        }
        #endregion 

        #region Methods
        public async Task<HttpResponseMessage> SendAsync<T>(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }
        #endregion Methods
    }
}

