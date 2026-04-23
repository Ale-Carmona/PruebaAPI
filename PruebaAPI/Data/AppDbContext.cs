using Microsoft.EntityFrameworkCore;
using PruebaAPI.Models;

namespace PruebaAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Tabla1> Tabla1 { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tabla1>().HasData(
                new Tabla1 { Id = 1, Nombre = "Juan", Apellido = "Pérez" },
                new Tabla1 { Id = 2, Nombre = "María", Apellido = "Gómez" },
                new Tabla1 { Id = 3, Nombre = "Carlos", Apellido = "López" }
            );


            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios { Id = 1, Matricula = 1, Nombre = "Juan", Edad = 20, Tipo = 1 },
                new Usuarios { Id = 2, Matricula = 2, Nombre = "María", Edad = 22, Tipo = 2 },
                new Usuarios { Id = 3, Matricula = 3, Nombre = "Carlos", Edad = 23, Tipo = 1 }
            );
        }
    }
}
