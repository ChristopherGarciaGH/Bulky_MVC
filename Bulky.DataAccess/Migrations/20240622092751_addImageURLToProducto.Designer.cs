﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240622092751_addImageURLToProducto")]
    partial class addImageURLToProducto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Nombre = "Accion"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Nombre = "Ciencia-Ficcion"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Nombre = "Historia"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListaPrecios")
                        .HasColumnType("float");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<double>("Precio100")
                        .HasColumnType("float");

                    b.Property<double>("Precio50")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Autor = "Billy Spark",
                            Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "SWD9999001",
                            IdCategoria = 1,
                            ImageURL = "",
                            ListaPrecios = 99.0,
                            Precio = 90.0,
                            Precio100 = 80.0,
                            Precio50 = 85.0,
                            Titulo = "Fortune of Time"
                        },
                        new
                        {
                            Id = 2,
                            Autor = "Nancy Hoover",
                            Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "CAW777777701",
                            IdCategoria = 2,
                            ImageURL = "",
                            ListaPrecios = 40.0,
                            Precio = 30.0,
                            Precio100 = 20.0,
                            Precio50 = 25.0,
                            Titulo = "Dark Skies"
                        },
                        new
                        {
                            Id = 3,
                            Autor = "Julian Button",
                            Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "RITO5555501",
                            IdCategoria = 3,
                            ImageURL = "",
                            ListaPrecios = 55.0,
                            Precio = 50.0,
                            Precio100 = 35.0,
                            Precio50 = 40.0,
                            Titulo = "Vanish in the Sunset"
                        },
                        new
                        {
                            Id = 4,
                            Autor = "Abby Muscles",
                            Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "WS3333333301",
                            IdCategoria = 1,
                            ImageURL = "",
                            ListaPrecios = 70.0,
                            Precio = 65.0,
                            Precio100 = 55.0,
                            Precio50 = 60.0,
                            Titulo = "Cotton Candy"
                        },
                        new
                        {
                            Id = 5,
                            Autor = "Ron Parker",
                            Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "SOTJ1111111101",
                            IdCategoria = 2,
                            ImageURL = "",
                            ListaPrecios = 30.0,
                            Precio = 27.0,
                            Precio100 = 20.0,
                            Precio50 = 25.0,
                            Titulo = "Rock in the Ocean"
                        },
                        new
                        {
                            Id = 6,
                            Autor = "Laura Phantom",
                            Descripcion = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "FOT000000001",
                            IdCategoria = 3,
                            ImageURL = "",
                            ListaPrecios = 25.0,
                            Precio = 23.0,
                            Precio100 = 20.0,
                            Precio50 = 22.0,
                            Titulo = "Leaves and Wonders"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Producto", b =>
                {
                    b.HasOne("Bulky.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
