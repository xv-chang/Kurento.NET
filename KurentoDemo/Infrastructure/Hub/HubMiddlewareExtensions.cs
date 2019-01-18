using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;

namespace KurentoDemo.Infrastructure.Hub
{
    public static class HubMiddlewareExtensions
    {
        public static IApplicationBuilder UseHub(this IApplicationBuilder app, Action<HubRouteBuilder> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }
            var routes = new RouteBuilder(app);
            var manager = (HubManager)app.ApplicationServices.GetService(typeof(HubManager));
            configure(new HubRouteBuilder(routes, manager));
            app.UseWebSockets();
            app.UseRouter(routes.Build());
            return app;
        }
    }
}
