using System.ComponentModel.DataAnnotations;

namespace MyAgenda.API.Dtos
{
    public class UsuarioParaLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}