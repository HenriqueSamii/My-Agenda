using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAgenda.API.Data.Class;

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

        /////////////////////// TODO: Raios que o partam do repositorio nao quer funcionar, ver isso depos //////////////////////////////
        
    }
}