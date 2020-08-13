using System;
using System.Collections.Generic;

namespace MyAgenda.API.Models.Class
{
    public class Estabelecimento
    {
        public Guid Id { get; set; }
        public bool Privado { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FunciomantoHorarios { get; set; }
        public string FunciomantoDiasDaSemana { get; set; }
    }
}