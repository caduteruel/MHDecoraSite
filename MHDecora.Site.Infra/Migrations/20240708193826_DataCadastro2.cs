using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Site.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DataCadastro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DataCadastro",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "TIMESTAMP(7)",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "TIMESTAMP(7)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DataCadastro",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "TIMESTAMP(7)",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "TIMESTAMP(7)",
            //    oldNullable: true);
        }
    }
}
