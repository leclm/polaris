using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polaris.Conteiner.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriasConteineres",
                columns: table => new
                {
                    CategoriaConteinerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoriaConteinerUuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasConteineres", x => x.CategoriaConteinerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposConteineres",
                columns: table => new
                {
                    TipoConteineroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoConteinerUuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Largura = table.Column<double>(type: "double", nullable: false),
                    Comprimento = table.Column<double>(type: "double", nullable: false),
                    Volume = table.Column<double>(type: "double", nullable: false),
                    PesoMaximo = table.Column<double>(type: "double", nullable: false),
                    Altura = table.Column<double>(type: "double", nullable: false),
                    ValorDiaria = table.Column<double>(type: "double", nullable: false),
                    ValorMensal = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposConteineres", x => x.TipoConteineroId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conteiner",
                columns: table => new
                {
                    ConteinerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConteinerUuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Fabricacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fabricante = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Material = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CategoriaConteinerId = table.Column<int>(type: "int", nullable: false),
                    TipoConteinerId = table.Column<int>(type: "int", nullable: false),
                    AluguelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiner", x => x.ConteinerId);
                    table.ForeignKey(
                        name: "FK_Conteiner_CategoriasConteineres_CategoriaConteinerId",
                        column: x => x.CategoriaConteinerId,
                        principalTable: "CategoriasConteineres",
                        principalColumn: "CategoriaConteinerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conteiner_TiposConteineres_TipoConteinerId",
                        column: x => x.TipoConteinerId,
                        principalTable: "TiposConteineres",
                        principalColumn: "TipoConteineroId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrestacaoDeServico",
                columns: table => new
                {
                    PrestacaoDeServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrestacaoDeServicoUuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataProcedimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstadoPrestacaoServico = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConteinerId = table.Column<int>(type: "int", nullable: false),
                    TerceirizadoId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_PrestacaoDeServico_Terceirizado_TerceirizadoId",
                        column: x => x.TerceirizadoId,
                        principalTable: "Terceirizado",
                        principalColumn: "TerceirizadoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasConteineres_Nome",
                table: "CategoriasConteineres",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conteiner_CategoriaConteinerId",
                table: "Conteiner",
                column: "CategoriaConteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conteiner_Codigo",
                table: "Conteiner",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conteiner_TipoConteinerId",
                table: "Conteiner",
                column: "TipoConteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoDeServico_ConteinerId",
                table: "PrestacaoDeServico",
                column: "ConteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoDeServico_DataProcedimento_ConteinerId_Terceirizado~",
                table: "PrestacaoDeServico",
                columns: new[] { "DataProcedimento", "ConteinerId", "TerceirizadoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoDeServico_ServicoId",
                table: "PrestacaoDeServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoDeServico_TerceirizadoId",
                table: "PrestacaoDeServico",
                column: "TerceirizadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposConteineres_Nome",
                table: "TiposConteineres",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrestacaoDeServico");

            migrationBuilder.DropTable(
                name: "Conteiner");

            migrationBuilder.DropTable(
                name: "CategoriasConteineres");

            migrationBuilder.DropTable(
                name: "TiposConteineres");
        }
    }
}
