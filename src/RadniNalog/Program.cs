using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RadniNalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .UseKestrel()
                //.UseUrls("http://DPED-IMALES:5000/#/home")
            //    .UseUrls("http://localhost:5000")
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();

            //host.Run();
          

            BuildWebHost(args).Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(kestrel=>kestrel.Listen(IPAddress.Parse("10.138.5.2"),5003))
            .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
