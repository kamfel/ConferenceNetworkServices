using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.DTO
{
    public class RoomDetailsDTO
    {
        public int RoomNumber { get; set; }
        public int Seats { get; set; }
        public string Layout { get; set; }
        public string Name { get; set; }
        public bool ExceptionInversion { get; set; }

        public string[] Devices { get; set; }
    }
}
