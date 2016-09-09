using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;
using Backend.Models;

namespace Backend
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello world!");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IContactRepository, ContactRepository>();
        }
    }
}