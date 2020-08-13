using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}