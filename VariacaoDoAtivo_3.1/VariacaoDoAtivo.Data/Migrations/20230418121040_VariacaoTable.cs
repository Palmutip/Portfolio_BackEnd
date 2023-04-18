using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VariacaoDoAtivo.Data.Migrations
{
    public partial class VariacaoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Variacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Dia = table.Column<int>(nullable: false),
                    Data = table.Column<string>(maxLength: 10, nullable: false),
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
                name: "Variacoes");
        }
    }
}
