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

        public static string GetFromAppSettings(string key)
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

       
    }
}
