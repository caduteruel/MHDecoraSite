using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTagOnTema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Tags",
            //    schema: "DECORAPHP",
            //    table: "MH_TEMA",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Tags",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "NVARCHAR2(2000)");

            //migrationBuilder.CreateTable(
            //    name: "MH_ORCAMENTO",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
            //        AindaNaoDefiniODia = table.Column<bool>(type: "NUMBER(1)", nullable: false),
            //        MaisInformacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_ORCAMENTO", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MH_ORCAMENTO");

            //migrationBuilder.DropColumn(
            //    name: "Tags",
            //    schema: "DECORAPHP",
            //    table: "MH_TEMA");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Tags",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NVARCHAR2(2000)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "NVARCHAR2(2000)",
            //    oldNullable: true);
        }
    }
}
