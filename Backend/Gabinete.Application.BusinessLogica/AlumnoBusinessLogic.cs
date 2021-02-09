using System;
using Gabinete.Domain.Repositorie;
using Microsoft.Extensions.Configuration;
using Gabinete.Dom.Models;

namespace Gabinete.Application.BusinessLogica
{
    public class AlumnoBusinessLogic
    {
        readonly AlumnoRepository _alumnRepository;

        private readonly IConfiguration _config;

        public AlumnoBusinessLogic(AlumnoRepository alumnoRepository , IConfiguration configuration)
        {
            _alumnRepository = alumnoRepository;
            _config = configuration;
        }

        public AlumnoModel GetAlumnoByDni (int dni)
        {
           
            AlumnoModel alumno = _alumnRepository.GetAlumno(dni);
            
            return alumno;
        }
    }
}
