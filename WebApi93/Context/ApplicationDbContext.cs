using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace WebApi93.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        //Agregar modelos
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Rol> roles { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Name = "Fernando",
                    User = "Usuario",
                    FkRol = 1,
                    Password = "1234"
                }
            );

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                }
            );
        }
    }
}
