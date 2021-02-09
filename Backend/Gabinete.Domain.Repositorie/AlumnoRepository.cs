using AutoMapper;
using Gabinete.Persistence.EFramework.context;
using System;
using System.Linq;
using Gabinete.Persistence.EFramework.entities;
using Gabinete.Dom.Models;

namespace Gabinete.Domain.Repositorie
{
    public class AlumnoRepository
    {
        private readonly GabineteContext _context;
        //private readonly IMapper _mapper;

        public AlumnoRepository(GabineteContext context)
        {
            _context = context;
            //_mapper = mapper;
        }

        public AlumnoModel GetAlumno(int dni)
        {
            
            try
            {
                var alumno = (from a in _context.AlumnosUS21
                            where a.Documento == dni
                            select new AlumnoModel
                            {
                                IdAlumno = a.IdAlumno,
                                Nombre = a.Nombre,
                                Apellido = a.Apellido,
                                Documento = a.Documento,
                                Edad = a.Edad,
                                EmailPrimario = a.EmailPrimario,
                                EmailSecundario = a.EmailSecundario,
                                Telefono = a.Telefono

                            }).FirstOrDefault();

                return alumno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
