using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ApiModels;

namespace WebApplication1
{
    public class BlackJackMain
    {
        public static void Main(string[] args)
        {

            System.Diagnostics.Debug.Print("blacjack start-tooo");
            GameObject go = new GameObject();

            //CreateWebHostBuilder(args).Build().Run();
            // here one can do threads??
            go.main();
            go.runGame();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
    }
}
