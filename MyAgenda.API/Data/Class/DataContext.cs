using Microsoft.EntityFrameworkCore;
using MyAgenda.API.Models.Class;

namespace MyAgenda.API.Data.Class
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// Entity Framework Builder
            // modelBuilder.Entity<Post>()
            //     .HasOne(p => p.Blog)
            //     .WithMany(b => b.Posts);

            //BlocoDaAgenda
            modelBuilder.Entity<BlocoDaAgenda>()
                .HasMany(p => p.Clientes)
                .WithMany(b => b.Agenda);

            // Usuario
            modelBuilder.Entity<Usuario>()
                .HasMany(p => p.FuncionarioDe)
                .WithOne(b => b.Conta);
            modelBuilder.Entity<Usuario>()
                .HasMany(p => p.MeusEstabelecimentos)
                .WithOne(b => b.Dono);

            //UsuarioBlocoDaAgenda
            modelBuilder.Entity<UsuarioBlocoDaAgenda>()
                .HasKey(pc => new { pc.UsuarioId, pc.BlocoDaAgendaId });

            modelBuilder.Entity<UsuarioBlocoDaAgenda>()
                .HasOne(pc => pc.Usuario)
                .WithMany(p => p.Agenda)
                .HasForeignKey(pc => pc.UsuarioId);

            modelBuilder.Entity<UsuarioBlocoDaAgenda>()
                .HasOne(pc => pc.BlocoDaAgenda)
                .WithMany(c => c.Clientes)
                .HasForeignKey(pc => pc.BlocoDaAgendaId); 
            
            //FuncionarioServico
            modelBuilder.Entity<FuncionarioServico>()
                .HasKey(pc => new { pc.FuncionarioId, pc.ServicoId });

            modelBuilder.Entity<FuncionarioServico>()
                .HasOne(pc => pc.Funcionario)
                .WithMany(p => p.Funcoes)
                .HasForeignKey(pc => pc.FuncionarioId);

            modelBuilder.Entity<FuncionarioServico>()
                .HasOne(pc => pc.Servico)
                .WithMany(c => c.Prestadores)
                .HasForeignKey(pc => pc.Servico); 
        }
        public DbSet<BlocoDaAgenda> BlocosDaAgenda { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}