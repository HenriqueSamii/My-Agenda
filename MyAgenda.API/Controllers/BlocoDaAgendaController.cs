using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAgenda.API.Data.Class;

namespace MyAgenda.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlocoDaAgendaController : ControllerBase
    {
        // private readonly IBlocoDaAgendaRepository repo;
        // public UsuarioController(IBlocoDaAgendaRepository repo)
        // {
        //     this.repo = repo;
        // }

        private readonly DataContext context;
        
        public BlocoDaAgendaController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("home")]
        public async Task<IActionResult> Home()
        {
            // var claimsIdentity = this.User.Identity as ClaimsIdentity;
            // ClaimsPrincipal currentUser = this.User;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || userId == "")
            {
                return BadRequest("Erro, porblema com token - Id não encontrado");
            }

            var usuarioRep = await AgendaDeUsuarioLogado(int.Parse(userId));
            return Ok(new{ usuariosBlocosDaAgenda = usuarioRep});
        }

        /////////////////////// TODO: Raios que o partam do repositorio nao quer funcionar, ver isso depos //////////////////////////////
        public IQueryable<UsuarioBlocoDaAgenda> GetAllUsuariosBlocosDaAgenda(){
            return rhis.context.UsuariosBlocosDaAgenda.AsQueryable(); 
        }

        public async Task<ICollection<UsuarioBlocoDaAgenda>> AgendaDeUsuarioLogado(int id)
        {
            var x = await GetAllUsuariosBlocosDaAgenda().Where(x => x.UsuarioId == id).ToListAsync(); 
            return x;
        }
    }
}