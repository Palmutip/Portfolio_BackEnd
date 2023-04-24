using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VariacaoDoAtivo.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2023, 4, 23, 19, 41, 51, 170, DateTimeKind.Local).AddTicks(8585)),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: false, defaultValue: "Teste")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2023, 4, 23, 19, 41, 51, 171, DateTimeKind.Local).AddTicks(5572)),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Dia = table.Column<int>(nullable: false),
                    Data = table.Column<string>(maxLength: 20, nullable: false),
                    Valor = table.Column<string>(nullable: true),
                    VaricaoRelacaoD1 = table.Column<string>(nullable: true),
                    VariacaoRelacaoPrimeiraData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variacoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Variacoes");
        }
    }
}
