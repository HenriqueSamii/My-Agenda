using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAgenda.API.Data.Class;
using MyAgenda.API.Models.Class;

namespace MyAgenda.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // private readonly IUsuarioRepository repo;
        // public UsuarioController(IUsuarioRepository repo)
        // {
        //     this.repo = repo;
        // }

        private readonly DataContext context;
        
        public UsuarioController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("home")]
        public async Task<IActionResult> Home()
        {
            // var usuarioRep = await ContaUsuarioLogado(1);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuarioRep = await ContaUsuarioLogado(int.Parse(userId));
            return Ok(new{ usuario = usuarioRep});
        }
        //[AllowAnonymous]
        // [HttpGet("todos")]
        // public async Task<IActionResult> TodosUsuarios()
        // {
        //     var usuariosRep = await TodosUsuariosR();
        //     return Ok(new{ usuarios = usuariosRep});
        // }


        /////////////////////// TODO: Raios que o partam do repositorio de usuario nao quer funcionar, ver isso depos //////////////////////////////
        public async Task<Usuario> ContaUsuarioLogado(int id)
        {
            var x = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Id == id); 
            return x;
        }

        public async Task<ICollection<Usuario>> TodosUsuariosR()
        {
            var x = await this.context.Usuarios.ToListAsync();
            return x;
        }
    }
}