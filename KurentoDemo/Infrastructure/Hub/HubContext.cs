using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace KurentoDemo.Infrastructure.Hub
{
    public class HubContext
    {
     
        public HttpContext HttpContext { set; get; }
        public WebSocket  WebSocket { set; get; }

    }
}
