using System;
using System.Collections.Generic;
using System.Text;
using Gabinete.Persistence.EFramework.entities;
using Microsoft.EntityFrameworkCore;

namespace Gabinete.Persistence.EFramework.context
{
    public partial class GabineteContext : DbContext
    {
        public GabineteContext()
        {

        }
        public GabineteContext(DbContextOptions<GabineteContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Alumnos> AlumnosUS21 { get; set;  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warningTo protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = server.bizuit.com; Initial Catalog = Labs; User ID = Labs; Password = Bizuit");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.Property(a => a.IdAlumno)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(a => a.Nombre)
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(a => a.Apellido)
                       .HasMaxLength(100)
                       .IsUnicode(false);

                entity.Property(a => a.Edad)
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(a => a.EmailPrimario)
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(a => a.EmailSecundario)
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(a => a.Telefono)
                   .HasMaxLength(100)
                   .IsUnicode(false);


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}

