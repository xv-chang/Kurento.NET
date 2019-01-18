using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurentoDemo.Infrastructure.Hub
{
    public interface IHub
    {
        HubContext Context { set; get; }
        Task OnConnectedAsync();
        Task OnDisconnectedAsync(Exception ex);
        void OnError(Exception ex);
    }
}
