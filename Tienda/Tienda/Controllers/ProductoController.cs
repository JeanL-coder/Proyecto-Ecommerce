
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tienda.Models;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        [HttpPost("agregar")]
        public async Task<ActionResult> agregarProducto([FromBody] Producto proObj)
        {
            if (proObj == null)
            {
                return BadRequest("El producto no puede ser nulo");
            }


        
            if (string.IsNullOrEmpty(proObj.Nombre) || string.IsNullOrEmpty(proObj.Descripcion) || proObj.Precio <= 0 || proObj.Stock <= 0 || proObj.GeneroID <= 0 || proObj.ProveedorID <= 0)
            {
                return BadRequest("Los campos del producto son inválidos");
            }


            _context.Productos.Add(proObj);
            await _context.SaveChangesAsync();


            return Ok(proObj);
        }

        [HttpPost("buscar")]
        public IActionResult RegistrarBusqueda(int productId)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == productId);
            if (producto != null)
            {
             
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        /*
        [HttpGet("mas-buscados")]
        public IActionResult GetProductosMasBuscados()
        {
            var productos = _context.Productos.OrderByDescending(p => p.Busquedas).Take(10).ToList();
            return Ok(productos);
        }
    }
        */
    }
}
