using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.SearchParameters
{
    public class DevicesParameter : SearchParameter
    {
        public DevicesParameter(string[] devices)
        {
            Name = "devices";
            Value = devices;
        }
    }
}
