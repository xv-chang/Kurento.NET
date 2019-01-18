using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KurentoDemo.Hubs;
using KurentoDemo.Infrastructure.Hub;
using KurentoDemo.Infrastructure.Kurento;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KurentoDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() => new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<KMSSettings>(Configuration.GetSection("KMSSettings").Get<KMSSettings>());
            services.AddSingleton<KMSServersManager>();
            services.AddSingleton<RoomsManager>();
            services.AddSingleton<UsersManager>();
            services.AddTransient<HelloWorldHub>();
            services.AddTransient<RoomHub>();
            services.AddSingleton<HubManager>();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseHub(routes =>
            {
                routes.MapHub<HelloWorldHub>("/HelloWorldHub");
                routes.MapHub<RoomHub>("/roomhub");
            });
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
