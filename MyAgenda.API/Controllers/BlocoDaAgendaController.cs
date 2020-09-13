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

        // [HttpGet("funcionario/home")]
        // public async Task<IActionResult> FuncionarioHome()
        // {
        //     // var claimsIdentity = this.User.Identity as ClaimsIdentity;
        //     // ClaimsPrincipal currentUser = this.User;
        //     var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //     if (userId == null || userId == "")
        //     {
        //         return BadRequest("Erro, porblema com token - Id não encontrado");
        //     }

        //     var usuarioRep = await AgendaDeUsuarioLogadoAgendaFuncinario(int.Parse(userId));
        //     return Ok(new{ usuariosBlocosDaAgenda = usuarioRep});
        // }

        [AllowAnonymous]
        [HttpPost("novo")]
        public async Task<IActionResult> Novo([FromBody] CriarBlocoDaAgendaDto criarBlocoDaAgendaDto)
        {
            var blocoAgenda = await this.CriarBlocoDaAgenda(criarBlocoDaAgendaDto);
            await this.LigarBlocoDaAgendaEstabelecimento(criarBlocoDaAgendaDto.EstabelecimentoId,blocoAgenda.Id);
            await this.LigarBlocoDaAgendaCliente(blocoAgenda.Id);
            // await this.LigarBlocoDaAgendaFuncionario(criarBlocoDaAgendaDto.FuncionarioId,blocoAgenda.Id);

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
                                .Include(i => i.BlocoDaAgenda)
                                    .ThenInclude(i => i.Clientes)
                                .Where(x => x.UsuarioId == id || x.BlocoDaAgenda.Prestadores.ToList().Any(i=> i.Conta.Id == id)).ToListAsync(); 
            return x;
        }
        // public async Task<ICollection<UsuarioBlocoDaAgenda>> AgendaDeUsuarioLogadoAgendaFuncinario(int id)
        // {
        //     var x = await GetAllUsuariosBlocosDaAgenda()
        //                         .Include(i => i.Usuario)
        //                         .Include(i => i.BlocoDaAgenda)
        //                             .ThenInclude(i => i.Prestadores)
        //                             .ThenInclude(i => i.Conta)
        //                         .Include(i => i.BlocoDaAgenda)
        //                             .ThenInclude(i => i.Servicos)
        //                         .Include(i => i.BlocoDaAgenda)
        //                             .ThenInclude(i => i.Local)
        //                         .Include(i => i.BlocoDaAgenda)
        //                             .ThenInclude(i => i.Clientes)
        //                         .Where(x => x.BlocoDaAgenda.Prestadores.ToList().Any(i=> i.Conta.Id == id)).ToListAsync(); 
        //     return x;
        // }

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
                                    new UsuarioBlocoDaAgenda{Usuario = usuarioCliente,BlocoDaAgenda= novoBloco}
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

        private  async Task<Estabelecimento> LigarBlocoDaAgendaEstabelecimento(int estabelecimentoId, int blocoAgendaId)
        {
            var local = await this.context.Estabelecimentos.Include(i => i.Agenda).FirstOrDefaultAsync(x => x.Id == estabelecimentoId);
            var blocoA = await this.context.BlocosDaAgenda.FirstOrDefaultAsync(x => x.Id == blocoAgendaId);
            //System.Console.WriteLine(local.Agenda);
            if (local.Agenda == null)
            {
                local.Agenda  =new List<BlocoDaAgenda>{blocoA};
            }
            else
            {
                local.Agenda.Add(blocoA);   
            }
            await this.context.SaveChangesAsync();
            return local;
        }

        private async Task<BlocoDaAgenda> LigarBlocoDaAgendaCliente(int blocoAgendaId)
        {
            //var usuarioCliente = await this.context.Usuarios.Include(i=>i.Agenda).FirstOrDefaultAsync(x => x.Email == clienteEmail);
            var blocoA = await this.context.BlocosDaAgenda.Include(i => i.Clientes).ThenInclude(i=>i.Usuario).FirstOrDefaultAsync(x => x.Id == blocoAgendaId);
            foreach (var item in blocoA.Clientes)
            {
                item.Usuario.Agenda.Add(item);
            }
            //usuarioCliente.Agenda.Add(blocoA.Clientes)
            await this.context.SaveChangesAsync();
            return blocoA;
        }
        // private async Task<Usuario> LigarBlocoDaAgendaFuncionario(int funcionarioId, int blocoAgendaId)
        // {
        //     var funcionarioPrestador = await this.context.Funcionarios
        //                                     .Include(i => i.Conta)
        //                                     .ThenInclude(i => i.Agenda)
        //                                     .FirstOrDefaultAsync(x => x.Id == funcionarioId);
        //     var blocoA = await this.context.BlocosDaAgenda.Include(i => i.Clientes).FirstOrDefaultAsync(x => x.Id == blocoAgendaId);
        //     funcionarioPrestador.Conta.Agenda.Add(blocoA.Clientes.ToList[0])
        //     await this.context.SaveChangesAsync();
        //     return funcionarioPrestador.Conta;
        // }
    }
}