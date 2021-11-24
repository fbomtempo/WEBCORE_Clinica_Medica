using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCORE_Clinica_Medica.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultaAgendamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    medico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especialidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaAgendamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    crm = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    especialidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.PrimaryKey("PK_Medico", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "money", nullable: false),
                    estoque = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TotalMovimentacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoMovimentacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalMovimentacoes = table.Column<int>(type: "int", nullable: false),
                    totalProdutos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalMovimentacoes", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProduto = table.Column<int>(type: "int", nullable: false),
                    movTipo = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Produto_idProduto",
                        column: x => x.idProduto,
                        principalTable: "Produto",
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

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_cpf",
                table: "Funcionario",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_cpf",
                table: "Medico",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_idProduto",
                table: "Movimentacao",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_cpf",
                table: "Paciente",
                column: "cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "ConsultaAgendamento");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "TotalMovimentacoes");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
