using System;
using System.Collections.Concurrent;

namespace KurentoDemo.Infrastructure.Hub
{
    public class HubManager
    {
        private readonly ConcurrentDictionary<string, IHub> _hubs;
        private readonly IServiceProvider _serviceProvider;
        public HubManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _hubs = new ConcurrentDictionary<string, IHub>();
        }

        public IHub GetHub(string connectionId, Type type)
        {
            if (!_hubs.TryGetValue(connectionId, out IHub hub))
            {
                hub = (IHub)_serviceProvider.GetService(type);
            }
            return hub;
        }

        public void RemoveHub(string connectionId)
        {
            _hubs.TryRemove(connectionId, out IHub _);
        }
    }
}
