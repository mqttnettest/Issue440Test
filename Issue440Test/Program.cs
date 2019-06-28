using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MQTTnet.AspNetCore;

namespace Issue440Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o => {
                        o.ListenAnyIP(1883, l => l.UseMqtt()); // mqtt pipeline
                        o.ListenAnyIP(5000); // default http pipeline
                    })
                .UseStartup<Startup>();
    }
}
