using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gabinete.Dom.Models;
using Gabinete.Application.BusinessLogica;
using System.Web;

namespace Gabinete.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnoBusinessLogic _alumnoBusinessLogic;

        public AlumnoController(AlumnoBusinessLogic alumnoBusinessLogic)
        {
            _alumnoBusinessLogic = alumnoBusinessLogic;
        }

        [HttpGet]
        //[Route("/{dni}")]
        public IActionResult GetAlumno()
        {
            int dni = 41439420;
            AlumnoModel user = _alumnoBusinessLogic.GetAlumnoByDni(dni);
            return Ok(user);
        }
    }
}
