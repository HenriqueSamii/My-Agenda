using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAgenda.API.Data.Class;
using MyAgenda.API.Dtos;
using MyAgenda.API.Models.Class;

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

        [HttpGet("meus")]
        public async Task<IActionResult> Meus()
        {
            // var claimsIdentity = this.User.Identity as ClaimsIdentity;
            // ClaimsPrincipal currentUser = this.User;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || userId == "")
            {
                return BadRequest("Erro, porblema com token - Id não encontrado");
            }

            var usuarioRep = await EstabelecimentosDeUsuarioLogado(int.Parse(userId));
            return Ok(new{ usuariosBlocosDaAgenda = usuarioRep});
        }
        [HttpGet("{nome}")]
        public async Task<IActionResult> EstabelecimentoPorNome(string nome)
        {
            var usuarioRep = await EstabelecimentoNome(nome);
            if (usuarioRep == null)
            {
                return BadRequest("Erro, estabelecimento nao existe");
            }
            return Ok(new{ usuariosBlocosDaAgenda = usuarioRep});
        }

        [HttpPost("novo")]
        public async Task<IActionResult> Novo([FromBody] EstabelecimentoDto estabelecimentoDto)
        {
            System.Console.WriteLine(estabelecimentoDto);
            if (await EstabelecimentoNome(estabelecimentoDto.Nome) != null)
            {
                return BadRequest("Estabelecimento com este nome já foi cadastrado");
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || userId == "")
            {
                return BadRequest("Erro, porblema com token - Id não encontrado");
            }
            //System.Console.WriteLine(usuarioParaRegistroDto.Nome);
            await this.CriarEstabelecimento(estabelecimentoDto,int.Parse(userId));

            return StatusCode(201);
        }

        /////////////////////// TODO: Raios que o partam do repositorio nao quer funcionar, ver isso depos //////////////////////////////
        public IQueryable<Estabelecimento> GetAllEstabelecimentos(){
            return this.context.Estabelecimentos.AsQueryable(); 
        }

        public async Task<ICollection<Estabelecimento>> EstabelecimentosDeUsuarioLogado(int id)
        {
            var x = await GetAllEstabelecimentos().Where(x => x.Dono.Id == id).ToListAsync(); 
            return x;
        }
        public async Task<Estabelecimento> EstabelecimentoNome(string nome)
        {
            var x = await this.context.Estabelecimentos.FirstOrDefaultAsync(x => x.Nome == nome); 
            return x;
        }

        public async Task<Estabelecimento> EstabelecimentoId(int id)
        {
            var x = await this.context.Estabelecimentos.FirstOrDefaultAsync(x => x.Id == id); 
            return x;
        }

        public async Task<Usuario> UasuarioId(int id)
        {
            var x = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Id == id); 
            return x;
        }

        public async Task<Estabelecimento> CriarEstabelecimento(EstabelecimentoDto esta,int id)
        {
            var dono = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            var estaNovo = new Estabelecimento{Nome = esta.Nome,Descricao= esta.Descricao, Dono=dono};
            await this.context.Estabelecimentos.AddAsync(estaNovo);
            var x = await this.context.Estabelecimentos.FirstOrDefaultAsync(x => x.Nome == estaNovo.Nome); 
            dono.MeusEstabelecimentos.Add(estaNovo);
            await this.context.SaveChangesAsync();
            return x;
        }
    }
}