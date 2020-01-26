using ConferenceNetworkServices.DTO;
using ConferenceNetworkServices.SearchParameters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceNetworkServices.Services
{
    public class RoomService : BaseService
    {
        public RoomService(HttpClient client) : base(client)
        {
        }

        public async Task<Tuple<HttpStatusCode, ICollection<RoomDTO>>> GetAllAsync()
        {
            return await GetAsync<ICollection<RoomDTO>>("rooms");
        }

        public async Task<HttpStatusCode> CreateAsync(RoomDetailsDTO room)
        {
            return await PostAsync("rooms", room);
        }

        public async Task<Tuple<HttpStatusCode, RoomDetailsDTO>> GetByIdAsync(uint id)
        {
            return await GetAsync<RoomDetailsDTO>($"rooms/{id}");
        }

        public async Task<HttpStatusCode> UpdateAsync(uint id, RoomDetailsDTO room)
        {
            return await PutAsync($"rooms/{id}", room);
        }

        public async Task<HttpStatusCode> RemoveAsync(uint id)
        {
            return await DeleteAsync($"rooms/{id}");
        }

        public async Task<Tuple<HttpStatusCode, ICollection<RoomDTO>>> FindAsync(SearchParameter[] parameters)
        {
            var queryString = String.Join("&", parameters.Select(p => p.AsQueryParameter()));

            return await GetAsync<ICollection<RoomDTO>>("rooms?" + queryString);
        }

        public async Task<Tuple<HttpStatusCode, ICollection<TimeFrameDTO>>> GetAvailableTimeFrames(uint id, DateTime date)
        {
            return await GetAsync<ICollection<TimeFrameDTO>>($"rooms/{id}?date=" + date.ToString("ddMMyyyy"));
        }

        public async Task<Tuple<HttpStatusCode, ICollection<TimeFrameDTO>>> GetAvailableTimeFrames(uint id, DateTime startingDate, DateTime endingDate)
        {
            return await GetAsync<ICollection<TimeFrameDTO>>($"rooms/{id}?start={startingDate.ToString("ddMMyyyyhhmmss")}&end={endingDate.ToString("ddMMyyyyhhmmss")}");
        }

        public async Task<HttpStatusCode> CreateSegment(uint roomId, TimeFrameDTO timeFrame)
        {
            return await PostAsync($"rooms/{roomId}/segments", timeFrame);
        }

        public async Task<HttpStatusCode> RemoveSegmentsInRange(uint roomId, TimeFrameDTO timeFrame)
        {
            return await DeleteAsync($"rooms/{roomId}/segments?start={timeFrame.Start.ToString("ddMMyyyyhhmmss")}&end={timeFrame.End.ToString("ddMMyyyyhhmmss")}");
        }
    }
}
