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
        [AllowAnonymous]
        [HttpGet("agenda/{numero}")]
        public async Task<IActionResult> EstabelecimentoPorId(int numero)
        {
            var usuarioRep = await EstabelecimentoId(numero);
            if (usuarioRep == null)
            {
                return BadRequest("Erro, porblema com estabelecimento - Id não encontrado");
            }
            return Ok(new{ estabelecimentoPorId = usuarioRep});
        }

        [AllowAnonymous]
        [HttpGet("{nome}")]
        public async Task<IActionResult> EstabelecimentoPorNome(string nome)
        {
            var usuarioRep = await EstabelecimentoNomeCompleto(nome);
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
        
        [HttpPost("funcionario/novo")]
        public async Task<IActionResult> NovoFuncionario([FromBody] CriarUsuarioComServicoDto criarUsuarioComServicoDto)
        {
            var FuncionarioServico = await CriarfuncionarioServico(criarUsuarioComServicoDto);
            await AfiliarEstabelecimentoServico(FuncionarioServico.Funcoes.ToArray()[0].ServicoId, criarUsuarioComServicoDto.EstabelecimentoId);

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

        public async Task<Estabelecimento> EstabelecimentoNomeCompleto(string nome)
        {
            var x = await this.context.Estabelecimentos
                        .Include(i => i.Servicos)
                            .ThenInclude(i => i.Prestadores)
                            .ThenInclude(i => i.Funcionario)
                            .ThenInclude(i => i.Conta)
                        .FirstOrDefaultAsync(x => x.Nome == nome); 
            return x;
        }
        public async Task<Estabelecimento> EstabelecimentoId(int id)
        {
            var x = await this.context.Estabelecimentos
                                .Include(i => i.Agenda)
                                .FirstOrDefaultAsync(x => x.Id == id); 
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

        private async Task<Funcionario> CriarfuncionarioServico(CriarUsuarioComServicoDto criarUsuarioComServicoDto)
        {
            Servico servicoFun = new Servico{Nome=criarUsuarioComServicoDto.NomeServico,
                                            TempoDeDuracao=criarUsuarioComServicoDto.TempoDeDuracao,
                                            Valor=criarUsuarioComServicoDto.Valor};
            var usuarioFuncionario = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Email == criarUsuarioComServicoDto.UsurioEmail);
            var estabelecimento = await this.context.Estabelecimentos.FirstOrDefaultAsync(x => x.Id == criarUsuarioComServicoDto.EstabelecimentoId);
            //estabelecimento.Servicos.Add(servicoFun);
            Funcionario novoFuncionario = new Funcionario{Activo=true,Conta=usuarioFuncionario,TrabalhaPara=estabelecimento};

             novoFuncionario.Funcoes = new List<FuncionarioServico>{new FuncionarioServico{Servico = servicoFun, Funcionario = novoFuncionario}};
            //novoFuncionario.Funcoes.Add(new FuncionarioServico{Servico = servicoFun, Funcionario = novoFuncionario});
            await this.context.Funcionarios.AddAsync(novoFuncionario);
            await this.context.SaveChangesAsync();
            
            return novoFuncionario;
        }

        private async Task<Estabelecimento>  AfiliarEstabelecimentoServico(int servicoId, int estabelecimentoId)
        {
            //System.Console.WriteLine( servicoId+ " " + estabelecimentoId);
            var estabelecimento = await this.context.Estabelecimentos.FirstOrDefaultAsync(x => x.Id == estabelecimentoId);
            var servico = await this.context.Servicos.FirstOrDefaultAsync(x => x.Id == servicoId);
            if (estabelecimento.Servicos == null)
            {
                estabelecimento.Servicos = new List<Servico>{servico};
            }else{
                estabelecimento.Servicos.Add(servico);
            }
            context.SaveChanges();
            return estabelecimento;
        }

        private async Task<Funcionario>  CriarFuncionario(CriarUsuarioComServicoDto criarUsuarioComServicoDto)
        {
            var usuarioFuncionario = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Email == criarUsuarioComServicoDto.UsurioEmail);
            var estabelecimento = await this.context.Estabelecimentos.FirstOrDefaultAsync(x => x.Id == criarUsuarioComServicoDto.EstabelecimentoId);
            Funcionario novoFuncionario = new Funcionario{Activo=true,Conta=usuarioFuncionario,TrabalhaPara=estabelecimento};

            await this.context.Funcionarios.AddAsync(novoFuncionario);
            await this.context.SaveChangesAsync();
            return novoFuncionario;
        }

        private async Task<int> CriarServico(CriarUsuarioComServicoDto criarUsuarioComServicoDto)
        {
            Servico servicoFun = new Servico{Nome=criarUsuarioComServicoDto.NomeServico,
                                            TempoDeDuracao=criarUsuarioComServicoDto.TempoDeDuracao,
                                            Valor=criarUsuarioComServicoDto.Valor};
            await this.context.Servicos.AddAsync(servicoFun);
            await this.context.SaveChangesAsync();
            return servicoFun.Id;
        }
    }
}