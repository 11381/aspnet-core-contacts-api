using System;
using Microsoft.AspNetCore.Hosting;

namespace Backend
{
    public class Program
    {
        public static void Main(){
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }   
}