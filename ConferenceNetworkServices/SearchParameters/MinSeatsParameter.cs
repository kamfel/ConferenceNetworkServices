using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.SearchParameters
{
    public class MinSeatsParameter : SearchParameter
    {
        public MinSeatsParameter(int minSeats)
        {
            Name = "minseats";
            Value = minSeats;
        }
    }
}
