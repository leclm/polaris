using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polaris.Conteiner.Migrations
{
    /// <inheritdoc />
    public partial class Adiciona_Prestacao_Servico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrestacaoDeServico",
                columns: table => new
                {
                    PrestacaoDeServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrestacaoDeServicoUuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataProcedimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comentario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConteinerId = table.Column<int>(type: "int", nullable: false),
                    TercerizadoId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestacaoDeServico", x => x.PrestacaoDeServicoId);
                    table.ForeignKey(
                        name: "FK_PrestacaoDeServico_Conteiner_ConteinerId",
                        column: x => x.ConteinerId,
                        principalTable: "Conteiner",
                        principalColumn: "ConteinerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestacaoDeServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestacaoDeServico_Terceirizado_TercerizadoId",
                        column: x => x.TercerizadoId,
                        principalTable: "Terceirizado",
                        principalColumn: "TerceirizadoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoDeServico_ConteinerId",
                table: "PrestacaoDeServico",
                column: "ConteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoDeServico_ServicoId",
                table: "PrestacaoDeServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoDeServico_TercerizadoId",
                table: "PrestacaoDeServico",
                column: "TercerizadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrestacaoDeServico");
        }
    }
}
