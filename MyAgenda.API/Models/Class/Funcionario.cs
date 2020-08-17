using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public bool Activo { get; set; }
        public Usuario Conta { get; set; }
        public Estabelecimento TrabalhaPara { get; set; }
        public ICollection<FuncionarioServico> Funcoes { get; set; }
        public string ActivoHorarios { get; set; }
        public string ActivoDiasDaSemana { get; set; }
        public int NivelDePermicao { get; set; }
    }
}