using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAgenda.API.Models.Class
{
    public class Funcionario
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        [Required]
        public Usuario Conta { get; set; }
        [Required]
        public Estabelecimento TrabalhaPara { get; set; }
        public ICollection<FuncionarioServico> Funcoes { get; set; }
        public string ActivoHorarios { get; set; }
        public string ActivoDiasDaSemana { get; set; }
        public int NivelDePermicao { get; set; }
    }
}