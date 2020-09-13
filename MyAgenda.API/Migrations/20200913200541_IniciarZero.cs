using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAgenda.API.Migrations
{
    public partial class IniciarZero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Usuarios_DonoId",
                table: "Estabelecimentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estabelecimentos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "DonoId",
                table: "Estabelecimentos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Usuarios_DonoId",
                table: "Estabelecimentos",
                column: "DonoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Usuarios_DonoId",
                table: "Estabelecimentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estabelecimentos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DonoId",
                table: "Estabelecimentos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Usuarios_DonoId",
                table: "Estabelecimentos",
                column: "DonoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
