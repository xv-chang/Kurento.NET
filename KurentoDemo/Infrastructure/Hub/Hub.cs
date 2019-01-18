using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurentoDemo.Infrastructure.Hub
{
    public class Hub : IHub
    {
        public HubContext Context { set; get; }
        public virtual Task OnConnectedAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisconnectedAsync(Exception ex)
        {
            return Task.CompletedTask;
        }

        public void OnError(Exception ex)
        {

        }
    }
}
