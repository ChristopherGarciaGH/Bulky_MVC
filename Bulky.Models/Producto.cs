using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        [Display(Name = "Lista Precios")]
        [Range(1,1000)]
        public double ListaPrecios { get; set; }

        [Required]
        [Display(Name = "Precio por 1 - 50")]
        [Range(1, 1000)]
        public double Precio { get; set; }

        [Required]
        [Display(Name = "Precio por + 50")]
        [Range(1, 1000)]
        public double Precio50 { get; set; }

        [Required]
        [Display(Name = "Precio por + 100")]
        [Range(1, 1000)]
        public double Precio100 { get; set; }

        //Añadir Clave Foranea (FK) en Entity Framework Core
        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        [ValidateNever]
        public Categoria Categoria { get; set; }

        //Añadir imagenes
        [ValidateNever]
        public string ImageURL { get; set; }
    }
}
