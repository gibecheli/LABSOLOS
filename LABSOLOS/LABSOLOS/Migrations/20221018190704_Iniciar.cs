using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LABSOLOS.Migrations
{
    public partial class Iniciar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analises",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amostra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<float>(type: "real", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    Propriedade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: false),
                    analiseid = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    dataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Analises_analiseid",
                        column: x => x.analiseid,
                        principalTable: "Analises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Financas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solicitacaoId = table.Column<int>(type: "int", nullable: false),
                    valorTotal = table.Column<float>(type: "real", nullable: false),
                    formaPag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    finalizado = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financas_Solicitacoes_solicitacaoId",
                        column: x => x.solicitacaoId,
                        principalTable: "Solicitacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financas_solicitacaoId",
                table: "Financas",
                column: "solicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_analiseid",
                table: "Solicitacoes",
                column: "analiseid");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_clienteid",
                table: "Solicitacoes",
                column: "clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financas");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Analises");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
