using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Site.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DataCadastrado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastrado",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM",
                type: "TIMESTAMP(7)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastrado",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM");
        }
    }
}
