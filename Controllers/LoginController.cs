using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using peliculas.Context;
using peliculas.Models;
//using peliculas.Models;


namespace peliculas.Controllers
{
    [Route("api/[controller]")]
    
    public class LoginController : ControllerBase // Fixed typo in class name
    {

        
        private readonly PeliculasDbContext context;

        public LoginController(PeliculasDbContext context)
        {
            this.context = context;
        }



        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login([FromBody] Usuario usuario)
        {
            string token = "";
            Usuario usuarioValido = context.Usuario.Where(u => u.Email == usuario.Email && u.Password == usuario.Password).FirstOrDefault();
            if (usuarioValido != null)
            {
                token = "token";
            }
            return Ok(token);

            
        }

    }
}