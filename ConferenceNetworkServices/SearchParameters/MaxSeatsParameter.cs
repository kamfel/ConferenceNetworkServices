using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.SearchParameters
{
    public class MaxSeatsParameter : SearchParameter
    {
        public MaxSeatsParameter(int maxSeats)
        {
            Name = "maxseats";
            Value = maxSeats;
        }
    }
}
