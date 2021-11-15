using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCORE_Clinica_Medica.Migrations
{
    public partial class MigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    idMedico = table.Column<int>(type: "int", nullable: false),
                    dataRealizacao = table.Column<DateTime>(type: "date", nullable: false),
                    dataAgendamento = table.Column<DateTime>(type: "date", nullable: false),
                    agendamentoStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Medico_idMedico",
                        column: x => x.idMedico,
                        principalTable: "Medico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Agendamento_Paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_idMedico",
                table: "Agendamento",
                column: "idMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_idPaciente",
                table: "Agendamento",
                column: "idPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");
        }
    }
}
