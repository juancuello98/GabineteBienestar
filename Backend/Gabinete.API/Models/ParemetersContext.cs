using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 

namespace Gabinete.API.Models
{
    public class ParemetersContext : DbContext
    {
        public ParemetersContext(DbContextOptions<ParemetersContext> options)
           : base(options)
        {
        }

        public DbSet<Parameters> Parametros { get; set; }
    }
}
