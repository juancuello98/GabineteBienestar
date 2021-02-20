using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GabineteBienestar.Models;

namespace GabineteBienestar.Models
{
    public class Common
    {
        public static async Task<string> LoginAsync()
        {
           
            var urlApi = Config.GetFromAppSettings("apiUrl") + "api/Login";
            var authorization = Encoding.UTF8.GetBytes(Config.GetFromAppSettings("bizuitUser") + ":" + Config.GetFromAppSettings("bizuitPassword"));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorization));
            var response = await client.GetAsync(urlApi);

            switch (response.StatusCode.ToString())
            {
                case "InternalServerError":
                            return "Error" + response.Content.ReadAsStringAsync().Result;
                case "NotFound":
                            return "Error" + response.Content.ReadAsStringAsync().Result;
                default:
                    var result = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);
                    return result.token;
            }
                
            
        }

    }
}
