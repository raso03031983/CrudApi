using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    rg = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataExclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEndereco",
                columns: table => new
                {
                    idClienteEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEndereco", x => x.idClienteEndereco);
                });

            migrationBuilder.CreateTable(
                name: "ClienteRedeSocial",
                columns: table => new
                {
                    idClienteRedeSocial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteRedeSocial", x => x.idClienteRedeSocial);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    idEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataExclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.idEndereco);
                });

            migrationBuilder.CreateTable(
                name: "RedeSocial",
                columns: table => new
                {
                    idRedeSocial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    redeSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tipoRedeSocial = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataExclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSocial", x => x.idRedeSocial);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    idTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tipoTelefone = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataExclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.idTelefone);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ClienteEndereco");

            migrationBuilder.DropTable(
                name: "ClienteRedeSocial");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "RedeSocial");

            migrationBuilder.DropTable(
                name: "Telefone");
        }
    }
}
