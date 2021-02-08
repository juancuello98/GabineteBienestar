using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gabinete.API.Models;

namespace Gabinete.API.Controllers
{

    
    [Route("api/Solicitud")]
    [ApiController]
    public class SolicitudController : Controller
    {


        [HttpGet]
        [Route("Motivos")]
        // GET: SolicitudController
        public List<string> getMotivos()
        {
            List<string> motivos = new List<string>();
            motivos.Add("Trabajo");
            motivos.Add("Familiar");
            motivos.Add("Estudio");
            return motivos;
        }

        [HttpGet]
        [Route("Alumno")]
        // GET: SolicitudController
        public Alumno getDatosAlumno()
        {
            Alumno alum = new Alumno();
            alum.Id = 1;
            alum.IsComplete = true;
            alum.Name = "Alan Silvester";

            return alum;
        }

        [HttpGet]
        [Route("preferenciaHoraria")]
        // GET: SolicitudController
        public List<string> getPreferenciaHoraria()
        {
            List<string> horarios = new List<string>();
            horarios.Add("Lunes de 9 a 13");
            horarios.Add("Martes de 16 a 20");
            horarios.Add("Viernes de 9 a 12");
            return horarios;
        }



        // POST: SolicitudController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitudController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SolicitudController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
