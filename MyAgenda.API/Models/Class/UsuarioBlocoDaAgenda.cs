namespace MyAgenda.API.Models.Class
{
    public class UsuarioBlocoDaAgenda
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int BlocoDaAgendaId { get; set; }
        public BlocoDaAgenda BlocoDaAgenda { get; set; }
    }
}