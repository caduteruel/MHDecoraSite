using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterMontagem4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<bool>(
            //    name: "MontagemDestaque",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    type: "NUMBER(1)",
            //    nullable: false,
            //    defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "MontagemDestaque",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM");
        }
    }
}
