using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConferenceNetworkServices.DTO;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConferenceNetworkServices.Services
{
    public class ReservationService : BaseService
    {
        public ReservationService(HttpClient address) : base(address)
        {
        }

        public async Task<HttpStatusCode> CreateAsync(ReservationDTO reservation)
        {
            return await PostAsync("reservations", reservation);
        }

        public async Task<Tuple<HttpStatusCode, ICollection<ReservationDTO>>> GetAllAsync()
        {
            return await GetAsync<ICollection<ReservationDTO>>("reservations");
        }

        public async Task<Tuple<HttpStatusCode, ReservationDTO>> GetByIdAsync(int id)
        {
            return await GetAsync<ReservationDTO>($"reservations/{id}");
        }

        public async Task<Tuple<HttpStatusCode, ICollection<ReservationDTO>>> GetAllForUserAsync(int userId)
        {
            return await GetAsync<ICollection<ReservationDTO>>($"users/{userId}/reservations");
        }

        public async Task<HttpStatusCode> UpdateAsync(int id, ReservationDTO reservation)
        {
            return await PutAsync($"reservations/{id}", reservation);
        }

        public async Task<HttpStatusCode> RemoveAsync(int id)
        {
            return await DeleteAsync($"reservations/{id}");
        }
    }
}
