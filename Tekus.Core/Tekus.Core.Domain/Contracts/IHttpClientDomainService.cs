using System.Net.Http;
using System.Threading.Tasks;

namespace Tekus.Core.Domain.Contrats
{
    public interface IHttpClientDomainService
    {
        Task<HttpResponseMessage> SendAsync<T>(HttpRequestMessage request);  
    }
}
