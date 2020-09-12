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
    public class FuncionarioController : ControllerBase
    {
        // private readonly IFuncionarioRepository repo;
        // public UsuarioController(IFuncionarioRepository repo)
        // {
        //     this.repo = repo;
        // }

        private readonly DataContext context;
        
        public FuncionarioController(DataContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> id(string id)
        {
            var usuarioRep = await funcionarioId(int.Parse(id));
            if (usuarioRep == null)
            {
                return BadRequest("Erro, estabelecimento nao existe");
            }
            return Ok(new{ usuariosBlocosDaAgenda = usuarioRep});
        }

        /////////////////////// TODO: Raios que o partam do repositorio nao quer funcionar, ver isso depos //////////////////////////////

        public async Task<Funcionario> funcionarioId(int id)
        {
            var x = await this.context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id); 
            return x;
        }
        
    }
}