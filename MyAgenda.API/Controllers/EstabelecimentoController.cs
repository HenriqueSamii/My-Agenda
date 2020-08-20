using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAgenda.API.Data.Class;

namespace MyAgenda.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        // private readonly IEstabelecimentoRepository repo;
        // public UsuarioController(IEstabelecimentoRepository repo)
        // {
        //     this.repo = repo;
        // }

        private readonly DataContext context;
        
        public EstabelecimentoController(DataContext context)
        {
            this.context = context;
        }

        /////////////////////// TODO: Raios que o partam do repositorio nao quer funcionar, ver isso depos //////////////////////////////
        
    }
}