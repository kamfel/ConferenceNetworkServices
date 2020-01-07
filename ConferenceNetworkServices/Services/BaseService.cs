using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceNetworkServices.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;

        public BaseService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        protected async Task<Tuple<HttpStatusCode, T>> GetAsync<T>(string requestUri) where T : class
        {
            var response = await _httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                return new Tuple<HttpStatusCode, T>(response.StatusCode, null);
            }

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(json);

            return new Tuple<HttpStatusCode, T>(response.StatusCode, data);
        }

        protected async Task<HttpStatusCode> PostAsync(string requestUri, object obj)
        {
            var roomJson = JsonConvert.SerializeObject(obj);
            var content = new StringContent(roomJson);

            var response = await _httpClient.PostAsync(requestUri, content);

            return response.StatusCode;
        }

        protected async Task<HttpStatusCode> PutAsync(string requestUri, object obj)
        {
            var roomJson = JsonConvert.SerializeObject(obj);
            var content = new StringContent(roomJson);

            var response = await _httpClient.PutAsync(requestUri, content);

            return response.StatusCode;
        }

        protected async Task<HttpStatusCode> DeleteAsync(string requestUri)
        {
            var response = await _httpClient.DeleteAsync(requestUri);

            return response.StatusCode;
        }
    }
}
