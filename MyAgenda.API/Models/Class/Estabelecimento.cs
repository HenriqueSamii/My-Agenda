using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAgenda.API.Models.Class
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        [Required]
        public Usuario Dono { get; set; }
        public bool Privado { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FunciomantoHorarios { get; set; }
        public string FunciomantoDiasDaSemana { get; set; }
        public ICollection<Usuario> UsuariosPermitidos { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<Servico> Servicos { get; set; }
        public ICollection<Produto> Estoque { get; set; }
        public ICollection<BlocoDaAgenda> Agenda { get; set; }
    }
}