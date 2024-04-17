using System.ComponentModel.DataAnnotations;

namespace Tienda.Models
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        public string Nombre { get; set; }
    }
}
