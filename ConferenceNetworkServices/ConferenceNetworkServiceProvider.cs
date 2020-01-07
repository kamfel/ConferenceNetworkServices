using ConferenceNetworkServices.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace ConferenceNetworkServices
{
    public class ConferenceNetworkServiceProvider
    {
        private readonly object _lock = new object();

        private HttpClient _httpClient = new HttpClient();

        private Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static ConferenceNetworkServiceProvider Instance { get; } = new ConferenceNetworkServiceProvider();

        private ConferenceNetworkServiceProvider()
        {

        }

        public T Get<T>() where T : BaseService
        {
            if (String.IsNullOrEmpty(_httpClient.BaseAddress.ToString()))
            {
                throw new MemberAccessException("No server adress has been provided.");
            }

            var type = typeof(T);

            lock (_lock)
            {
                if (!_services.ContainsKey(type))
                {
                    _services.Add(type, Activator.CreateInstance(type, new object[] { _httpClient }));
                }
            }
            return _services[type] as T;
        }

        public ConferenceNetworkServiceProvider UseServerAPIAdress(string address)
        {
            _httpClient.BaseAddress = new Uri(address);

            return this;
        }
    }
}
