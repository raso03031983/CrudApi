using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class createbooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Cod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "LivroAssunto",
                columns: table => new
                {
                    LivroCod = table.Column<int>(type: "int", nullable: false),
                    AssuntoCod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Assunto_AssuntoCod",
                        column: x => x.AssuntoCod,
                        principalTable: "Assunto",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Livro_LivroCod",
                        column: x => x.LivroCod,
                        principalTable: "Livro",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    LivroCod = table.Column<int>(type: "int", nullable: false),
                    AutorCod = table.Column<int>(type: "int", nullable: false),
                    AssuntoCod = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_AssuntoCod",
                        column: x => x.AssuntoCod,
                        principalTable: "Autor",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_LivroCod",
                        column: x => x.LivroCod,
                        principalTable: "Livro",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_AssuntoCod",
                table: "LivroAssunto",
                column: "AssuntoCod");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_LivroCod",
                table: "LivroAssunto",
                column: "LivroCod");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AssuntoCod",
                table: "LivroAutor",
                column: "AssuntoCod");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_LivroCod",
                table: "LivroAutor",
                column: "LivroCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAssunto");

            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
