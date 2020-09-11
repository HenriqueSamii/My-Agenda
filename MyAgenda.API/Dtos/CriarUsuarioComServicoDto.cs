namespace MyAgenda.API.Dtos
{
    public class CriarUsuarioComServicoDto
    {
        public string UsurioEmail { get; set; }
        public string NomeServico { get; set; }
        public decimal Valor { get; set; }
        public string TempoDeDuracao { get; set; } 
        public int EstabelecimentoId { get; set; }
    }
}