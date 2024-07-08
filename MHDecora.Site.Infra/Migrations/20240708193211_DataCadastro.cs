using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Site.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DataCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DataCadastro",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "TIMESTAMP(7)",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<int>(
            //    name: "TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NUMBER(10)",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Ordem",
            //    schema: "DECORAPHP",
            //    table: "MH_BANNERS",
            //    type: "NUMBER(10)",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_MH_MONTAGEM_TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    column: "TemaId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MH_MONTAGEM_MH_TEMA_TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    column: "TemaId",
            //    principalSchema: "DECORAPHP",
            //    principalTable: "MH_TEMA",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_MH_MONTAGEM_MH_TEMA_TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropIndex(
            //    name: "IX_MH_MONTAGEM_TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "DataCadastro",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "Ordem",
            //    schema: "DECORAPHP",
            //    table: "MH_BANNERS");
        }
    }
}
