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
            //BlocoDaAgenda
            modelBuilder.Entity<BlocoDaAgenda>()
                .HasMany(p => p.Prestadores)
                .WithOne();
            modelBuilder.Entity<BlocoDaAgenda>()
                .HasMany(p => p.Servicos)
                .WithOne();
            modelBuilder.Entity<BlocoDaAgenda>()
                .HasMany(p => p.Cesta)
                .WithOne();

            //Estabelecimento
            modelBuilder.Entity<Estabelecimento>()
                .HasIndex(u => u.Nome)
                .IsUnique();
            modelBuilder.Entity<Estabelecimento>()
                .HasMany(p => p.Agenda)
                .WithOne(b => b.Local);
            modelBuilder.Entity<Estabelecimento>()
                .HasMany(p => p.Estoque)
                .WithOne();
            modelBuilder.Entity<Estabelecimento>()
                .HasMany(p => p.Servicos)
                .WithOne();
            modelBuilder.Entity<Estabelecimento>()
                .HasMany(p => p.Funcionarios)
                .WithOne(b => b.TrabalhaPara);
            modelBuilder.Entity<Estabelecimento>()
                .HasMany(p => p.UsuariosPermitidos)
                .WithOne();

            // Usuario
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
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
                .HasForeignKey(pc => pc.ServicoId); 
        }
        public DbSet<BlocoDaAgenda> BlocosDaAgenda { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioServico> FuncionariosServicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioBlocoDaAgenda> UsuariosBlocosDaAgenda { get; set; }
    }
}