using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tekus.Core.Infrastructure.Helper
{
    public static class HandlerHttpClient
    {
        # region Fields
     
        private const string _contentTypeSuport = "application/json";

        #endregion fields

        #region Methods

        public static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                    return default;
                case HttpStatusCode.OK:
                    return await CreateResponseOk<T>(response);
                default:
                    throw new Exception($"Ha ocurrido un error en el consumo del servicio. Status code: {response.StatusCode} {response.Headers} Content: { await response.Content.ReadAsStringAsync()}");
            }
        }

        public static async Task<T> CreateResponseOk<T>(HttpResponseMessage response)
        {

            string jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { WriteIndented = true ,PropertyNamingPolicy = JsonNamingPolicy.CamelCase, };
            return JsonSerializer.Deserialize<T>(jsonString, options);   
        }
             
        public static HttpRequestMessage CreateRequest(HttpMethod method, string uriString)
        {
            Uri uri = new Uri(uriString);
            HttpRequestMessage request = new HttpRequestMessage(method, uri);
            request.Headers.Add("Accept", _contentTypeSuport);
            return request;
        }

        #endregion Methods
    }

}
