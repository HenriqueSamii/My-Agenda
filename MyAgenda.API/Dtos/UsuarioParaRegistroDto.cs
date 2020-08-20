using System.ComponentModel.DataAnnotations;

namespace MyAgenda.API.Dtos
{
    public class UsuarioParaRegistroDto
    {
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}