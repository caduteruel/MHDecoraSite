using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class novoscamposendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "LinkEndereco",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LinkMapa",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "CaminhoImagem",
            //    schema: "DECORAPHP",
            //    table: "MH_CATEGORIAS",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "NVARCHAR2(2000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "LinkEndereco",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO");

            //migrationBuilder.DropColumn(
            //    name: "LinkMapa",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO");

            //migrationBuilder.AlterColumn<string>(
            //    name: "CaminhoImagem",
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
