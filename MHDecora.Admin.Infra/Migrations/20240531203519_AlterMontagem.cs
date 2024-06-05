using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterMontagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "CaminhoImagem",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "NVARCHAR2(2000)");

            //migrationBuilder.AddColumn<string>(
            //    name: "CaminhoImagem2",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "CaminhoImagem3",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "CaminhoImagem4",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "CategoriaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NUMBER(10)",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "Descricao",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "Destaque",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "BOOLEAN",
            //    nullable: true,
            //    defaultValue: false);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Descricao",
            //    schema: "DECORAPHP",
            //    table: "MH_CATEGORIAS",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "NVARCHAR2(2000)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MH_MONTAGEM_CategoriaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    column: "CategoriaId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MH_MONTAGEM_MH_CATEGORIAS_CategoriaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    column: "CategoriaId",
            //    principalSchema: "DECORAPHP",
            //    principalTable: "MH_CATEGORIAS",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_MH_MONTAGEM_MH_CATEGORIAS_CategoriaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropIndex(
            //    name: "IX_MH_MONTAGEM_CategoriaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "CaminhoImagem2",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "CaminhoImagem3",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "CaminhoImagem4",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "CategoriaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "Descricao",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.DropColumn(
            //    name: "Destaque",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.AlterColumn<string>(
            //    name: "CaminhoImagem",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "NVARCHAR2(2000)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Descricao",
            //    schema: "DECORAPHP",
            //    table: "MH_CATEGORIAS",
            //    type: "NVARCHAR2(2000)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "NVARCHAR2(2000)",
            //    oldNullable: true);
        }
    }
}
