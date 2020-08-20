using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyAgenda.API.Data.Class;
using MyAgenda.API.Data.Interface;
using MyAgenda.API.Dtos;
using MyAgenda.API.Models.Class;

namespace MyAgenda.API.Controllers
{
    //[Authorize]
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
            var usuarioRep = await ContaUsuarioLogado(1);
            return Ok(new{ usuario = usuarioRep});
        }

        [HttpGet("todos")]
        public async Task<IActionResult> TodosUsuarios()
        {
            var usuariosRep = await TodosUsuariosR();
            return Ok(new{ usuarios = usuariosRep});
        }


        /////////////////////// TODO: Porra do repositorio de usuario nao quer funcionar, ver isso depos //////////////////////////////
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