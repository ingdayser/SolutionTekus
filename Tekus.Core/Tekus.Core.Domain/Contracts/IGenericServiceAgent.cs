using System;
using System.Threading.Tasks;

namespace Tekus.Core.Domain.ServiceAgentContrats
{
    public interface IGenericServiceAgent
    {
        Task<T> PostAsync<T>(string url, Object body);

        Task<T> GetAsync<T>(string url);
    }
}
