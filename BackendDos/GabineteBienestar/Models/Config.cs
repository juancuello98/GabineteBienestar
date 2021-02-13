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

        public static string GetFromAppSettings(string key)
        {
            var _result = "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            // ### Verificar por si toma como igual cuando esta escrito con distintas minusculuas y mayusculas
            // Ejemplo : ApiUrl {A, a}

            switch (key)
            {
                case "apiUrl":
                    Configuration = builder.Build();
                    _result = Configuration["apiUrl"];
                    return _result;

                case "bizuitUser":
                    Configuration = builder.Build();
                    _result = Configuration[key];
                    return _result;

                case "bizuitPassword":
                    Configuration = builder.Build();
                    _result = Configuration[key];
                    return _result;


                case "responseTypeId":
                    Configuration = builder.Build();
                    _result = Configuration[key];
                    return _result;


                case "responseTypeName":
                    Configuration = builder.Build();
                    _result = Configuration[key];
                    return _result;


                case "componentName":
                    Configuration = builder.Build();
                    _result = Configuration[key];
                    return _result;

                default:
                    return _result;
            }
             

        }

        //public static string GetUserName()
        //{
        //    var builder = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json");
        //    Configuration = builder.Build();
        //    var bizuitUserName = Configuration["bizuitUser"];

        //    return bizuitUserName;
        //}

        //public static string GetUserPassword()
        //{
        //    var builder = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json");
        //    Configuration = builder.Build();
        //    var bizuitUserPassword = Configuration["bizuitPassword"];

        //    return bizuitUserPassword;
        //}
    }
}
