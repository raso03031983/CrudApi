using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cod",
                table: "LivroAutor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Cod",
                table: "LivroAssunto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor",
                column: "Cod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroAssunto",
                table: "LivroAssunto",
                column: "Cod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroAssunto",
                table: "LivroAssunto");

            migrationBuilder.DropColumn(
                name: "Cod",
                table: "LivroAutor");

            migrationBuilder.DropColumn(
                name: "Cod",
                table: "LivroAssunto");
        }
    }
}
