using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Data
{
    /*
    * Configuración básica Entity Framework:
    * Esta clase se va a encargar de manejar la conexión que hemos escrito
    * en el JSON
    */
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Migración de la tabla Categorias
        public DbSet<Categoria> Categorias { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Categoria>().HasData(
                    new Categoria { Id = 1, Nombre = "Accion", DisplayOrder = 1 },
                    new Categoria { Id = 2, Nombre = "Ciencia-Ficcion", DisplayOrder = 2 },
                    new Categoria { Id = 3, Nombre = "Historia", DisplayOrder = 3 }
                    );
            }
    }
}
