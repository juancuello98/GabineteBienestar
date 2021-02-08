using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Gabinete.API.Models
{
    public class AlumnoContext : DbContext
    {
        public AlumnoContext(DbContextOptions<AlumnoContext> options)
           : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}
