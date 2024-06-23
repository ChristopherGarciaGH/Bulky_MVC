using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
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
        public DbSet<Producto> Productos { get; set; }

        //Siembra de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Accion", DisplayOrder = 1},
                new Categoria { Id = 2, Nombre = "Ciencia-Ficcion", DisplayOrder = 2 },
                new Categoria { Id = 3, Nombre = "Historia", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Titulo = "Fortune of Time",
                    Autor = "Billy Spark",
                    Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListaPrecios = 99,
                    Precio = 90,
                    Precio50 = 85,
                    Precio100 = 80,
                    IdCategoria = 1,
                    ImageURL = ""
                },
                new Producto
                {
                    Id = 2,
                    Titulo = "Dark Skies",
                    Autor = "Nancy Hoover",
                    Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListaPrecios = 40,
                    Precio = 30,
                    Precio50 = 25,
                    Precio100 = 20,
                    IdCategoria = 2,
                    ImageURL = ""
                },
                new Producto
                {
                    Id = 3,
                    Titulo = "Vanish in the Sunset",
                    Autor = "Julian Button",
                    Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListaPrecios = 55,
                    Precio = 50,
                    Precio50 = 40,
                    Precio100 = 35,
                    IdCategoria = 3,
                    ImageURL = ""
                },
                new Producto
                {
                    Id = 4,
                    Titulo = "Cotton Candy",
                    Autor = "Abby Muscles",
                    Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListaPrecios = 70,
                    Precio = 65,
                    Precio50 = 60,
                    Precio100 = 55,
                    IdCategoria = 1,
                    ImageURL = ""
                },
                new Producto
                {
                    Id = 5,
                    Titulo = "Rock in the Ocean",
                    Autor = "Ron Parker",
                    Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListaPrecios = 30,
                    Precio = 27,
                    Precio50 = 25,
                    Precio100 = 20,
                    IdCategoria = 2,
                    ImageURL = ""
                },
                new Producto
                {
                    Id = 6,
                    Titulo = "Leaves and Wonders",
                    Autor = "Laura Phantom",
                    Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListaPrecios = 25,
                    Precio = 23,
                    Precio50 = 22,
                    Precio100 = 20,
                    IdCategoria = 3,
                    ImageURL = ""
                }
                );
        }
    }
}
