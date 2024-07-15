using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addtemaonmontagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NUMBER(10)",
            //    nullable: true);

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
            //    name: "TemaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");
        }
    }
}
