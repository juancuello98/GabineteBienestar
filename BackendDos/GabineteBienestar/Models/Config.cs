using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            return GetSecretOrEnvVar("apiUrl");
        }

        public static string GetUser()
        {
            return GetSecretOrEnvVar("bizuitUser");
        }

        public static string GetPass()
        {
            return GetSecretOrEnvVar("bizuitPassword");
        }

        public static string GetComponentName()
        {
            return GetSecretOrEnvVar("componentName");
        }

        public static string GetResponse()
        {
            return GetSecretOrEnvVar("responseTypeName");
        }

        public static string GetProName()
        {
            return GetSecretOrEnvVar("processName");
        }


        public static string GetSecretOrEnvVar(string key)
        {
            const string DOCKER_SECRET_PATH = "/run/secrets/";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            if (Directory.Exists(DOCKER_SECRET_PATH))
            {
                IFileProvider provider = new PhysicalFileProvider(DOCKER_SECRET_PATH);
                IFileInfo fileInfo = provider.GetFileInfo("appsettings.json");
                if (fileInfo.Exists)
                {
                    using (var stream = fileInfo.CreateReadStream())
                    using (var streamReader = new StreamReader(stream))
                    {
                        var result = JsonConvert.DeserializeObject<JToken>(streamReader.ReadToEnd());
                        var value = result.Value<string>(key) ?? "";
                        if (String.IsNullOrEmpty(value))
                        {
                            return Configuration.GetValue<string>(key);
                        }
                        return value;
                    }
                }
            }
            return Configuration.GetValue<string>(key);
        }
        //public static string GetFromAppSettings(string key)
        //{
        //    var _result = "";
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json");

        //    // ### Verificar por si toma como igual cuando esta escrito con distintas minusculuas y mayusculas
        //    // Ejemplo : ApiUrl {A, a}

        //    try
        //    {
        //        Configuration = builder.Build();
        //        _result = Configuration[key];
        //        return _result;

        //    }
        //    catch (Exception)
        //    {

        //        return _result;
        //    }
        //}

        //switch (key)
        //{
        //    case "apiUrl":
        //        Configuration = builder.Build();
        //        _result = Configuration["apiUrl"];
        //        return _result;

        //    case "bizuitUser":
        //        Configuration = builder.Build();
        //        _result = Configuration[key];
        //        return _result;

        //    case "bizuitPassword":
        //        Configuration = builder.Build();
        //        _result = Configuration[key];
        //        return _result;


        //    case "responseTypeId":
        //        Configuration = builder.Build();
        //        _result = Configuration[key];
        //        return _result;


        //    case "responseTypeName":
        //        Configuration = builder.Build();
        //        _result = Configuration[key];
        //        return _result;


        //    case "componentName":
        //        Configuration = builder.Build();
        //        _result = Configuration[key];
        //        return _result;

        //    default:
        //        return _result;
        //}


        //}

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
