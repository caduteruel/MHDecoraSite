using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM");

            migrationBuilder.AddColumn<int>(
                name: "MontagemId",
                schema: "DECORAPHP",
                table: "MH_TAGS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MH_TAGS_MontagemId",
                schema: "DECORAPHP",
                table: "MH_TAGS",
                column: "MontagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MH_TAGS_MH_MONTAGEM_MontagemId",
                schema: "DECORAPHP",
                table: "MH_TAGS",
                column: "MontagemId",
                principalSchema: "DECORAPHP",
                principalTable: "MH_MONTAGEM",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MH_TAGS_MH_MONTAGEM_MontagemId",
                schema: "DECORAPHP",
                table: "MH_TAGS");

            migrationBuilder.DropIndex(
                name: "IX_MH_TAGS_MontagemId",
                schema: "DECORAPHP",
                table: "MH_TAGS");

            migrationBuilder.DropColumn(
                name: "MontagemId",
                schema: "DECORAPHP",
                table: "MH_TAGS");

            migrationBuilder.DropColumn(
                name: "TagId",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }
    }
}
