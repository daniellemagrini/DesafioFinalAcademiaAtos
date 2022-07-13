using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFinalAcademiaAtos.Migrations
{
    public partial class Inicialcriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pergunta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    solucao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alternativaA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alternativaB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alternativaC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alternativaD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alternativaE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    numero_endereco = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
