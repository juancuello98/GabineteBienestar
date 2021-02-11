using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GabineteBienestar.Models
{
    public static class Config
    {
        public static IConfigurationRoot Configuration;

        public static string GetUrlApi()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            var apiUrl = Configuration["apiUrl"];
            
            return apiUrl;
        }

        public static string GetUserName()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            var bizuitUserName = Configuration["bizuitUser"];

            return bizuitUserName;
        }

        public static string GetUserPassword()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            var bizuitUserPassword = Configuration["bizuitPassword"];

            return bizuitUserPassword;
        }
    }
}
