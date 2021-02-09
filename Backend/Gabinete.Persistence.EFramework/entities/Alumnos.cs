using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gabinete.Persistence.EFramework.entities
{
    
    public class Alumnos
    {
       [Key]
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public int Edad { get; set; }
        public string EmailPrimario { get; set; }
        public string EmailSecundario { get; set; }
        public string Telefono { get; set; }

    }
}
