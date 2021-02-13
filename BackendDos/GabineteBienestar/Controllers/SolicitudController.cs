﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GabineteBienestar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GabineteBienestar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
     
        [HttpGet]
        [Route("loguear")]

        public async Task<string> LoginAsync()
        {
            var bizuitToken = await Common.LoginAsync();

            /* Cambiar esto, hay que poner un try catch, lo que hace este metodo es devolver el token
            a traves del metodo LoginAsync(), este string despues se guarda en el Localstorage del navegador */

            if (!bizuitToken.Contains("Error"))
            {
                return bizuitToken;
            }
            else
            {
                return "No fue autorizado por algun motivo";
            }

        }


        [HttpGet]
        [Route("GetReasons")]
        public async Task<IActionResult> GetReasons([FromHeader(Name = "bizuitToken")] string bizuitToken)
        {
            /* Actualmente esta trayendo los datos del plugin PersonasFer, del componente persona,
             * hay que cambiarlo para que apunte hacia el plugin Tipos, componente parameters, filtrando
             por motivos */

            /* Estoy tomando esta url como ejemplo para armar la variable urlApi */
            /* http://server.bizuit.com/TyconLabsBIZUITDashboardAPI/api/{NombreComponente}/{NombreEntidad}?parameters=[]&sort=&page=1&size=10 */

            /* Armo la url, el config tiene un metodo GetFromAppSettings en el cual se la pasa por parametro el nombre
             * del nodo donde esta el valor que necesitamos, debe ser exactamente igual*/

            var urlApi = Config.GetFromAppSettings("apiUrl") + "api/" + Config.GetFromAppSettings("componentName") + "/" + Config.GetFromAppSettings("responseTypeName") + "?parameters=[]&sort=&page=1&size=10";
            var cliente = new HttpClient();
            
            /*Aca se le agrega en la cabecera , en el Header de la solicitud http, una key con su value para 
             * permitir obtener autorizacion de bizuit*/
            cliente.DefaultRequestHeaders.Add("BZ-AUTH-TOKEN", "Basic " + bizuitToken) ;

            /* Ejecuto el get llamando a la api de bizuit*/
            var response = await cliente.GetAsync(urlApi);

            /*Tomo el response, que es lo que me respondio bizuit y copio el contenido en el result*/
            var result = await response.Content.ReadAsStringAsync();

            /* Aca verifico que la respuesta haya sido un codigo exitoso , si no lo es devuelve los siguientes
             codigos de error */
            if (!response.IsSuccessStatusCode)
            {
                if(response.ReasonPhrase == "Unauthorizade")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, result);
                }
                else if (response.ReasonPhrase == "InternalServerError")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
                else if (response.ReasonPhrase == "NotFound")
                {
                    return StatusCode(StatusCodes.Status404NotFound, result);
                }
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        [Route("GetTimePreferences")]
        public async Task<IActionResult> GetTimesPreferences([FromHeader(Name = "bizuitToken")] string bizuitToken)
        {
            // Aca hay que cambiar los nombres que completan la ruta de la api, trayendo el plugin "Tipos", componente "Parameters"
            // pero filtrando por parameterTypeName = 'Horarios' y asi lo mismo con motivos.

            //http://server.bizuit.com/TyconLabsBIZUITDashboardAPI/api/{NombreComponente}/{NombreEntidad}?parameters=[]&sort=&page=1&size=10
            var urlApi = Config.GetFromAppSettings("apiUrl") + "api/" + Config.GetFromAppSettings("componentName") + "/" + Config.GetFromAppSettings("responseTypeName") + "?parameters=[]&sort=&page=1&size=10";
            var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("BZ-AUTH-TOKEN", "Basic " + bizuitToken);
            var response = await cliente.GetAsync(urlApi);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                if (response.ReasonPhrase == "Unauthorizade")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, result);
                }
                else if (response.ReasonPhrase == "InternalServerError")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
                else if (response.ReasonPhrase == "NotFound")
                {
                    return StatusCode(StatusCodes.Status404NotFound, result);
                }
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
