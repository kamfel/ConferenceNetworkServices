using ConferenceNetworkServices.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceNetworkServices.Services
{
    public class UserService : BaseService
    {
        public UserService(HttpClient client) : base(client)
        {
        }

        public void LogOut()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<HttpStatusCode> LogInAsync(UserAuthDTO user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            var content = new StringContent(userJson);

            var response = await _httpClient.PostAsync("login", content);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", body);
            }

            return response.StatusCode;
        }

        public async Task<Tuple<HttpStatusCode, string>> RegisterAsync(UserRegisterDTO user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            var content = new StringContent(userJson);

            var response = await _httpClient.PostAsync("register", content);

            var body = await response.Content.ReadAsStringAsync();

            return new Tuple<HttpStatusCode, string>(response.StatusCode, body);
        }

        public async Task<Tuple<HttpStatusCode, ICollection<UserDTO>>> GetAllAsync()
        {
            return await GetAsync<ICollection<UserInfoDTO>>("users");
        }

        public async Task<Tuple<HttpStatusCode, UserInfoDTO>> GetByIdAsync(uint id)
        {
            return await GetAsync<UserInfoDTO>($"users/{id}");
        }

        public async Task<HttpStatusCode> RemoveAsync(uint id)
        {
            return await DeleteAsync($"users/{id}");
        }


    }
}
