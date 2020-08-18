using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAgenda.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Activo = table.Column<bool>(nullable: false),
                    ContaId = table.Column<int>(nullable: false),
                    TrabalhaParaId = table.Column<int>(nullable: false),
                    ActivoHorarios = table.Column<string>(nullable: true),
                    ActivoDiasDaSemana = table.Column<string>(nullable: true),
                    NivelDePermicao = table.Column<int>(nullable: false),
                    BlocoDaAgendaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    BlocoDaAgendaId = table.Column<int>(nullable: true),
                    EstabelecimentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    TempoDeDuracao = table.Column<string>(nullable: true),
                    BlocoDaAgendaId = table.Column<int>(nullable: true),
                    EstabelecimentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionariosServicos",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false),
                    ServicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosServicos", x => new { x.FuncionarioId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_FuncionariosServicos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosBlocosDaAgenda",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    BlocoDaAgendaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosBlocosDaAgenda", x => new { x.UsuarioId, x.BlocoDaAgendaId });
                });

            migrationBuilder.CreateTable(
                name: "BlocosDaAgenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cancelado = table.Column<bool>(nullable: false),
                    Notas = table.Column<string>(nullable: true),
                    Comeco = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    LocalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlocosDaAgenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EstabelecimentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DonoId = table.Column<int>(nullable: false),
                    Privado = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    FunciomantoHorarios = table.Column<string>(nullable: true),
                    FunciomantoDiasDaSemana = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Usuarios_DonoId",
                        column: x => x.DonoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlocosDaAgenda_LocalId",
                table: "BlocosDaAgenda",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_DonoId",
                table: "Estabelecimentos",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_Nome",
                table: "Estabelecimentos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_BlocoDaAgendaId",
                table: "Funcionarios",
                column: "BlocoDaAgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ContaId",
                table: "Funcionarios",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TrabalhaParaId",
                table: "Funcionarios",
                column: "TrabalhaParaId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosServicos_ServicoId",
                table: "FuncionariosServicos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_BlocoDaAgendaId",
                table: "Produtos",
                column: "BlocoDaAgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstabelecimentoId",
                table: "Produtos",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_BlocoDaAgendaId",
                table: "Servicos",
                column: "BlocoDaAgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EstabelecimentoId",
                table: "Servicos",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstabelecimentoId",
                table: "Usuarios",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosBlocosDaAgenda_BlocoDaAgendaId",
                table: "UsuariosBlocosDaAgenda",
                column: "BlocoDaAgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Estabelecimentos_TrabalhaParaId",
                table: "Funcionarios",
                column: "TrabalhaParaId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Usuarios_ContaId",
                table: "Funcionarios",
                column: "ContaId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_BlocosDaAgenda_BlocoDaAgendaId",
                table: "Funcionarios",
                column: "BlocoDaAgendaId",
                principalTable: "BlocosDaAgenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estabelecimentos_EstabelecimentoId",
                table: "Produtos",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_BlocosDaAgenda_BlocoDaAgendaId",
                table: "Produtos",
                column: "BlocoDaAgendaId",
                principalTable: "BlocosDaAgenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Estabelecimentos_EstabelecimentoId",
                table: "Servicos",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_BlocosDaAgenda_BlocoDaAgendaId",
                table: "Servicos",
                column: "BlocoDaAgendaId",
                principalTable: "BlocosDaAgenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosBlocosDaAgenda_Usuarios_UsuarioId",
                table: "UsuariosBlocosDaAgenda",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosBlocosDaAgenda_BlocosDaAgenda_BlocoDaAgendaId",
                table: "UsuariosBlocosDaAgenda",
                column: "BlocoDaAgendaId",
                principalTable: "BlocosDaAgenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlocosDaAgenda_Estabelecimentos_LocalId",
                table: "BlocosDaAgenda",
                column: "LocalId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Estabelecimentos_EstabelecimentoId",
                table: "Usuarios",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Estabelecimentos_EstabelecimentoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "FuncionariosServicos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "UsuariosBlocosDaAgenda");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "BlocosDaAgenda");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
