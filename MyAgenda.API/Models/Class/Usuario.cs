using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAgenda.API.Models.Class
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<UsuarioBlocoDaAgenda> Agenda { get; set; }
        public ICollection<Estabelecimento> MeusEstabelecimentos { get; set; }
        public ICollection<Funcionario> FuncionarioDe { get; set; }
    }
}