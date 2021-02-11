﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GabineteBienestar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GabineteBienestar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        //List<Alumno> listaAlumnos = new List<Alumno>();

        [HttpGet]
        [Route("loguear")]

        public async Task<IActionResult> LoginAsync()
        {
            var bizuitToken = await Common.LoginAsync();

            if (!bizuitToken.Contains("Error"))
            {
                return Ok(bizuitToken);
            }
            else
            {
                return Unauthorized();
            }
            
        }


        [HttpGet]
        [Route("motivos")]
        public IActionResult getMotivos()
        {
            List<string> ListaMotivos = new List<string>();
            ListaMotivos.Add("Familia");
            ListaMotivos.Add("Trabajo");
            ListaMotivos.Add("Estudio");
            return Ok(ListaMotivos);
        }

        [HttpPost]
        [Route("datosAlumno")]
        public async Task<IActionResult> getDatosAlumno()
        {
                Alumno _alumno = new Alumno();
                _alumno.Documento = 41439420;
                _alumno.Nombre = "Juan Cuello";
                return Ok(_alumno);           
        }

        [HttpGet]
        [Route("horarios")]
        public IActionResult getPreferenciaHoraria()
        {
            List<string> ListaHorarios = new List<string>();
            ListaHorarios.Add("Lunes de 9 a 13");
            ListaHorarios.Add("Martes de 10 a 16");
            ListaHorarios.Add("Viernes de 9 a 17");
            return Ok(ListaHorarios);
        }

        //[HttpPost]
        //[Route("sendDataAlumno")]
        //public async T<IActionResult> sendData (string token)
        //{
        //    //listaAlumnos.Add(alumno);
        //    //return Ok(listaAlumnos);
        //}
    }
}
