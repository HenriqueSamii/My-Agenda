namespace MyAgenda.API.Models.Class
{
    public class FuncionarioServico
    {
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}