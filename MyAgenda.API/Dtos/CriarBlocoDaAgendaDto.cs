using System;

namespace MyAgenda.API.Dtos
{
    public class CriarBlocoDaAgendaDto
    {
        public string ClienteEmail { get; set; }
        public int FuncionarioId { get; set; }
        public int ServicoId { get; set; }
        public int EstabelecimentoId { get; set; }
        public string Inicio { get; set; }
    }
}