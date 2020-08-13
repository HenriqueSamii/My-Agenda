using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public List<BlocoDaAgenda> Agenda { get; set; }
        public List<Estabelecimento> MeusEstabelecimentos { get; set; }
        public List<Funcionario> FuncionarioDe { get; set; }
    }
}