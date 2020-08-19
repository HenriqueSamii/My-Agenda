using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyAgenda.API.Data.Interface;
using MyAgenda.API.Dtos;
using MyAgenda.API.Models.Class;

namespace MyAgenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAuthRepository repo;
        private readonly IConfiguration config;
        public AutenticacaoController(IAuthRepository repo, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Resister(UsuarioParaRegistroDto usuarioParaRegistroDto)
        {
            //validate request
            usuarioParaRegistroDto.Username = usuarioParaRegistroDto.Username.ToLower();
            if (await repo.UserExists(usuarioParaRegistroDto.Email))
            {
                return BadRequest("Este E-mail já foi cadastrado");
            }
            var userToCreate = new Usuario { Username = usuarioParaRegistroDto.Username, Email = usuarioParaRegistroDto.Email};
            var createdUser = await this.repo.Register(userToCreate, usuarioParaRegistroDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioParaLoginDto usuarioParaLoginDto)
        {
            var userFromRepo = await this.repo.Login(usuarioParaLoginDto.Email.ToLower(), usuarioParaLoginDto.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
                 new Claim(ClaimTypes.Email, userFromRepo.Email),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    this.config.GetSection(
                        "AppSettings:Token").Value));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new{token = tokenHandler.WriteToken(token)}); 
        }
    }
}