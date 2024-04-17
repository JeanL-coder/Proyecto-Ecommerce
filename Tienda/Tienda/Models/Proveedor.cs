using System.ComponentModel.DataAnnotations;

namespace Tienda.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio.")]
        public string Nombre { get; set; }

    }
}

