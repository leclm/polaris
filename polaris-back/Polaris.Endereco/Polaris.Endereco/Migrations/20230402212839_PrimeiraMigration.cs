using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polaris.Endereco.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoUuid",
                table: "Enderecos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EnderecoUuid",
                table: "Enderecos",
                column: "EnderecoUuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EnderecoUuid",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EnderecoUuid",
                table: "Enderecos");
        }
    }
}
