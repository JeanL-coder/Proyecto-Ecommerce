using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tienda.Models;

public class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El precio del producto es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio del producto debe ser mayor que cero.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El stock del producto es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock del producto debe ser mayor o igual que cero.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "La categoría del producto es obligatoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "La categoría del producto debe ser un número positivo.")]
    public int GeneroID { get; set; }

    [Required(ErrorMessage = "El proveedor del producto es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El proveedor del producto debe ser un número positivo.")]
    public int ProveedorID { get; set; }

    public string Talla { get; set; }

    public string Color { get; set; }

    public string ImagenUrl { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;


    [ForeignKey("Genero")]
    public int GenerofId { get; set; }
    public Genero Genero { get; set; }

    [ForeignKey("Proveedor")]
    public int ProveedorfId { get; set; }
    public Proveedor Proveedor { get; set; }
}

