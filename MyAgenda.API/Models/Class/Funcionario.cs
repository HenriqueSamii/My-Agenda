using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public Usuario Conta { get; set; }
        public Estabelecimento TrabalhaPara { get; set; }
        public List<Servico> Funcoes { get; set; }
        public DateTime HoraDeEntrada { get; set; } 
        public DateTime HoraDeSaida { get; set; } 
        public int NivelDePermicao { get; set; }
    }
}