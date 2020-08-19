using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyAgenda.API.Data.Interface;

namespace MyAgenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController
    {
        private readonly IUsuarioRepository repo;
        private readonly IConfiguration config;
        public UsuarioController(IUsuarioRepository repo, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
        }
    }
}