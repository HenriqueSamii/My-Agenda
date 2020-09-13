using System;
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

        [AllowAnonymous]
        [HttpPost("novo")]
        public async Task<IActionResult> Novo([FromBody] CriarBlocoDaAgendaDto criarBlocoDaAgendaDto)
        {
            var blocoAgenda = await this.CriarBlocoDaAgenda(criarBlocoDaAgendaDto);
            // await this.LigarBlocoDaAgenda(criarBlocoDaAgendaDto,blocoAgenda);

            return StatusCode(201);
        }

        /////////////////////// TODO: Raios que o partam do repositorio nao quer funcionar, ver isso depos //////////////////////////////
        public IQueryable<UsuarioBlocoDaAgenda> GetAllUsuariosBlocosDaAgenda(){
            return this.context.UsuariosBlocosDaAgenda.AsQueryable(); 
        }

        public async Task<ICollection<UsuarioBlocoDaAgenda>> AgendaDeUsuarioLogado(int id)
        {
            var x = await GetAllUsuariosBlocosDaAgenda()
                                .Include(i => i.Usuario)
                                .Include(i => i.BlocoDaAgenda)
                                    .ThenInclude(i => i.Prestadores)
                                    .ThenInclude(i => i.Conta)
                                .Include(i => i.BlocoDaAgenda)
                                    .ThenInclude(i => i.Servicos)
                                .Include(i => i.BlocoDaAgenda)
                                    .ThenInclude(i => i.Local)
                                .Where(x => x.UsuarioId == id).ToListAsync(); 
            return x;
        }

        public async Task<BlocoDaAgenda> CriarBlocoDaAgenda(CriarBlocoDaAgendaDto criarBlocoDaAgendaDto)
        {
            DateTime myDate = DateTime.ParseExact(criarBlocoDaAgendaDto.Inicio, "dd-MM-yyyy HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            var usuarioCliente = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Email == criarBlocoDaAgendaDto.ClienteEmail);
            var funcionarioPrestador = await this.context.Funcionarios.Include(i => i.Conta).FirstOrDefaultAsync(x => x.Id == criarBlocoDaAgendaDto.FuncionarioId);
            var local = await this.context.Estabelecimentos.Include(i => i.Agenda).FirstOrDefaultAsync(x => x.Id == criarBlocoDaAgendaDto.FuncionarioId);
            var servicoPrestado = await this.context.Servicos.FirstOrDefaultAsync(x => x.Id == criarBlocoDaAgendaDto.ServicoId);


            BlocoDaAgenda novoBloco = new BlocoDaAgenda{Comeco = myDate,
                                                        Cancelado = false,
                                                        Servicos = new List<Servico>{servicoPrestado},
                                                        Local = local,
                                                        Prestadores = new List<Funcionario>{funcionarioPrestador},
                                                        // Clientes = new List<UsuarioBlocoDaAgenda>()
                                                        };
            novoBloco.Clientes = new List<UsuarioBlocoDaAgenda>{
                                    new UsuarioBlocoDaAgenda{Usuario = usuarioCliente,BlocoDaAgenda= novoBloco},
                                    new UsuarioBlocoDaAgenda{Usuario = funcionarioPrestador.Conta,BlocoDaAgenda= novoBloco}
                                };
            
            await this.context.BlocosDaAgenda.AddAsync(novoBloco);
            await this.context.SaveChangesAsync();
            //System.Console.WriteLine(local.Agenda);
            // if (local.Agenda == null)
            // {
            //     local.Agenda  =new List<BlocoDaAgenda>{novoBloco};
            // }
            // else
            // {
            //     local.Agenda.Add(novoBloco);   
            // }
            // await this.context.SaveChangesAsync();
            return novoBloco;
        }
    }
}