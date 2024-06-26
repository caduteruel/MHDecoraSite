using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLinkTema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "LinkTema",
            //    schema: "DECORAPHP",
            //    table: "MH_TEMA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "LinkTema",
            //    schema: "DECORAPHP",
            //    table: "MH_TEMA",
            //    type: "NVARCHAR2(2000)",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
