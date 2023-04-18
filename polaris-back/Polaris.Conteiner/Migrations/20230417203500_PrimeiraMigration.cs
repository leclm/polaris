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
                name: "Conteiner",
                columns: table => new
                {
                    ConteinerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConteinerUuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Fabricacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Material = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Disponivel = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiner", x => x.ConteinerId);
                })
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
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ConteinerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasConteineres", x => x.CategoriaConteinerId);
                    table.ForeignKey(
                        name: "FK_CategoriasConteineres_Conteiner_ConteinerId",
                        column: x => x.ConteinerId,
                        principalTable: "Conteiner",
                        principalColumn: "ConteinerId");
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
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ConteinerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposConteineres", x => x.TipoConteineroId);
                    table.ForeignKey(
                        name: "FK_TiposConteineres_Conteiner_ConteinerId",
                        column: x => x.ConteinerId,
                        principalTable: "Conteiner",
                        principalColumn: "ConteinerId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasConteineres_ConteinerId",
                table: "CategoriasConteineres",
                column: "ConteinerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasConteineres_Nome",
                table: "CategoriasConteineres",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conteiner_Codigo",
                table: "Conteiner",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposConteineres_ConteinerId",
                table: "TiposConteineres",
                column: "ConteinerId");

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
                name: "CategoriasConteineres");

            migrationBuilder.DropTable(
                name: "TiposConteineres");

            migrationBuilder.DropTable(
                name: "Conteiner");
        }
    }
}
