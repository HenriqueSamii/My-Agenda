using System.ComponentModel.DataAnnotations;

namespace MyAgenda.API.Dtos
{
    public class EstabelecimentoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        //public string FunciomantoHorarios { get; set; }
        //public string FunciomantoDiasDaSemana { get; set; }
    }
}