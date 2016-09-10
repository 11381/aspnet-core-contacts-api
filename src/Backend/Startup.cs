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
            app.UseCors("wideopen");

            app.UseMvc();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Everything is fine, don't panic.");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("wideopen", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSingleton<IContactRepository, ContactRepository>();
        }
    }
}