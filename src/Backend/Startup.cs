using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;  
using Microsoft.Extensions.Configuration;  
// using Microsoft.Extensions.DependencyInjection;  
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using Backend.Models;

// using Microsoft.AspNetCore.Builder;  
// using Microsoft.AspNetCore.Hosting;  
// using Microsoft.Extensions.Configuration;  
// using Microsoft.Extensions.DependencyInjection;  
// using Microsoft.Extensions.Logging;

namespace Backend
{
    public class Startup
    {

        // public Startup(IHostingEnvironment env)
        // {
        //     Configuration = new ConfigurationBuilder()
        //         .SetBasePath(env.ContentRootPath)
        //         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //         .Build();

        //     HostingEnvironment = env;
        // }

        // public IConfigurationRoot Configuration { get; }
        // public IHostingEnvironment HostingEnvironment { get; }

        // public void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddTransient<IContactRepository, ContactRepository>();
        //     services.AddMvc();
        //     // other services
        // }

        // public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        // {
        //         // middleware configuration
        // }
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello from ASP.NET Core!");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<IContactRepository, ContactRepository>();
        }

    }
}