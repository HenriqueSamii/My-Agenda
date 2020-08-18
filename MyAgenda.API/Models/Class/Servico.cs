using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class Servico
    {
        public int Id { get; set; }
        public ICollection<FuncionarioServico> Prestadores { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string TempoDeDuracao { get; set; } 
    }
}