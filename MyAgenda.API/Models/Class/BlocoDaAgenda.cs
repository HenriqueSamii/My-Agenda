using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class BlocoDaAgenda
    {
        public int Id { get; set; }
        public bool Cancelado { get; set; }
        public string Notas { get; set; }
        public DateTime Comeco { get; set; } 
        public DateTime Fim { get; set; } 
        public ICollection<UsuarioBlocoDaAgenda> Clientes { get; set; }
        public ICollection<Funcionario> Prestadores { get; set; }
        public ICollection<Servico> Servicos { get; set; }
        public ICollection<Produto> Cesta { get; set; }
        public Estabelecimento Local { get; set; }
    }
}