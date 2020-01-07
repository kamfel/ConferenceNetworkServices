using ConferenceNetworkServices.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceNetworkServices.Services
{
    public class DeviceService : BaseService
    {
        public DeviceService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Tuple<HttpStatusCode, ICollection<DeviceDTO>>> GetAllAsync()
        {
            return await GetAsync<ICollection<DeviceDTO>>("devices");
        }

        public async Task<HttpStatusCode> CreateAsync(DeviceDTO device)
        {
            return await PostAsync("devices", device);
        }

        public async Task<HttpStatusCode> UpdateAsync(uint id, DeviceDTO device)
        {
            return await PutAsync($"devices/{id}", device);
        }

        public async Task<HttpStatusCode> DeleteAsync(uint id)
        {
            return await DeleteAsync($"devices/{id}");
        }
    }
}
