using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class correction_name_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "TipoTransacao");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Assunto",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Assunto",
                newName: "Titulo");

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    IdConta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    documento_cliente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.IdConta);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransacao",
                columns: table => new
                {
                    IdTipoTransacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransacao", x => x.IdTipoTransacao);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    IdTransacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdConta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoTransacao = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.IdTransacao);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Conta",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacao_TipoTransacao_IdTipoTransacao",
                        column: x => x.IdTipoTransacao,
                        principalTable: "TipoTransacao",
                        principalColumn: "IdTipoTransacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_IdConta",
                table: "Transacao",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_IdTipoTransacao",
                table: "Transacao",
                column: "IdTipoTransacao");
        }
    }
}
