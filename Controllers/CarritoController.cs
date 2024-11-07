using Microsoft.AspNetCore.Mvc;
using peliculas.Context;
using peliculas.Models;

namespace peliculas.Controllers
{
    [Route("api/[controller]")]
    public class CarritoController : Controller
    {
        private readonly PeliculasDbContext context;
        public CarritoController(PeliculasDbContext context)
        {
            this.context = context;
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult Comprar([FromBody] List<Carrito> carrito)
        {
            try
            {
                //foreach (var item in carrito)
                //{
                //    context.Carrito.Add(item);

                //}

                foreach (var item in carrito)
                {
                    var exists = context.Carrito.Any(c => c.idUsuario == item.idUsuario && c.idPelicula == item.idPelicula);
                    if (!exists)
                    {
                        context.Carrito.Add(item);
                    }
                }
                context.SaveChanges();
                return Ok(carrito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
