using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConferenceNetworkServices.SearchParameters
{
    public class SearchParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }  
        
        public string AsQueryParameter()
        {
            if (Value is IEnumerable)
            {
                return Name + "=" + string.Join(",", Value as IEnumerable);
            }
            else
            {
                return Name + "=" + Convert.ToString(Value);
            }
        }
    }
}
