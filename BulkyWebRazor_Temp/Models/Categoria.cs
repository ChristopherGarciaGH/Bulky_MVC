using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor_Temp.Models
{
        public class Categoria
        {
            [Key]
            public int Id { get; set; }
            [Required]
            [MaxLength(30)]
            [DisplayName("Nombre Categoria")]
            public string Nombre { get; set; }
            [DisplayName("Display Order")]
            [Range(1, 100, ErrorMessage = "Display Order debe estar entre 1 y 100")]
            public int DisplayOrder { get; set; }
        }
}
