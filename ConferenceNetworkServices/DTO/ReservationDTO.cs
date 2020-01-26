using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.DTO
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndingTime { get; set; }

        public string UserEmail { get; set; }
    }
}
