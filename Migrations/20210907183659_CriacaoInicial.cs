using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCORE_Clinica_Medica.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    rg = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telres = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    telcel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_cpf",
                table: "Paciente",
                column: "cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
