using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    /*
     * En esta clase hemos creado una de las tablas
     * para la base de datos.
     */
	public class Categoria
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Nombre Categoria")]
        public string Nombre { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order debe estar entre 1 y 100")]
        public int DisplayOrder { get; set; }
    }
}
