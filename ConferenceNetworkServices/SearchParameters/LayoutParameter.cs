using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.SearchParameters
{
    public class LayoutParameter : SearchParameter
    {
        public LayoutParameter(string[] layouts)
        {
            Name = "layout";
            Value = layouts;
        }
    }
}
