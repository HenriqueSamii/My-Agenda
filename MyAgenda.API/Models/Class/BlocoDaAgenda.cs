using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class BlocoDaAgenda
    {
        public Guid Id { get; set; }
        public bool Canselado { get; set; }
        public string Notas { get; set; }
        public DateTime Comeco { get; set; } 
        public DateTime Fim { get; set; } 
        public List<Usuario> Clientes { get; set; }
        public List<Funcionario> Prestadores { get; set; }
        public List<Servico> Servicos { get; set; }
        public List<Produto> Cesta { get; set; }
        public Estabelecimento Local { get; set; }
    }
}