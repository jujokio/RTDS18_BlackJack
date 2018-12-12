using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication1.ApiModels;

namespace WebApplication1
{
    public class Program
    {
        //public static List<ChatApiModel> Chat = new List<ChatApiModel>();
        //public static List<GameObject> listOfGames = new List<GameObject>();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            //int i = 0;
            //GameObject go = new GameObject();
            //listOfGames.Add(go);
            //while (i<=3){
            //    System.Diagnostics.Debug.WriteLine("start new game");
            //    go.main();
            //    go.runGame();

            //    i++;
            //}
            //System.Diagnostics.Debug.WriteLine("ended");

            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
