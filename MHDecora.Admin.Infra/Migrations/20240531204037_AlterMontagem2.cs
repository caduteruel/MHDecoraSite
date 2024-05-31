using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterMontagem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Destaque",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.AddColumn<bool>(
            //    name: "DestaqueMontagem",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "BOOLEAN",
            //    nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "DestaqueMontagem",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");

            //migrationBuilder.AddColumn<bool>(
            //    name: "Destaque",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "BOOLEAN",
            //    nullable: false,
            //    defaultValue: false);
        }
    }
}
