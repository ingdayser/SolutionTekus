using Domain.Services;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tekus.Core.Domain.Contrats;
using Tekus.Core.Domain.ServiceAgentContrats;
using Tekus.Core.Infrastructure.Helper;

namespace Tekus.Core.Infrastructure.ServiceAgent
{
    public class GenericServiceAgent : IGenericServiceAgent
    {
        #region Fields

        private const string _contentTypeSuport = "application/json";   
        private readonly IHttpClientDomainService _genericHttpClient = new HttpClientDomainService();

        #endregion      

        #region Methods

        public async Task<T> GetAsync<T>(string url)

        {
            using (HttpRequestMessage request = HandlerHttpClient.CreateRequest(HttpMethod.Get, url))
            {
                HttpResponseMessage response = await _genericHttpClient.SendAsync<T>(request);
                return await HandlerHttpClient.Deserialize<T>(response);
            }
        }
        public async Task<T> PostAsync<T>(string url, object body)
        {
            using (HttpRequestMessage request = HandlerHttpClient.CreateRequest(HttpMethod.Post, url))
            {           
                if (body != null)
                {
                    request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, _contentTypeSuport);
                }
                var response = await _genericHttpClient.SendAsync<T>(request);
                return await HandlerHttpClient.Deserialize<T>(response);
            }
        }     

        #endregion
    }
}
