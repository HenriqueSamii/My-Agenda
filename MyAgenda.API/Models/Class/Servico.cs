using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class Servico
    {
        public Guid Id { get; set; }
        public List<Funcionario> Prestadores { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime TempoDeDuracao { get; set; } 
    }
}