using ConferenceNetworkServices.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceNetworkServices.Services
{
    public class LayoutService : BaseService
    {
        public LayoutService(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<Tuple<HttpStatusCode, ICollection<LayoutDTO>>> GetAllAsync()
        {
            return await GetAsync<ICollection<LayoutDTO>>("layouts");
        }

        public async Task<HttpStatusCode> CreateAsync(LayoutDTO layout)
        {
            return await PostAsync("layouts", layout);
        }

        public async Task<HttpStatusCode> UpdateAsync(uint id, LayoutDTO layout)
        {
            return await PutAsync($"layouts/{id}", layout);
        }

        public async Task<HttpStatusCode> DeleteAsync(uint id)
        {
            return await DeleteAsync($"layouts/{id}");
        }
    }
}
