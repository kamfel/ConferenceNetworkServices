using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.DTO
{
    public class AvailabilityTimeFrameDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsAvaiable { get; set; }
    }
}
