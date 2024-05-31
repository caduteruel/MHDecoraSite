using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Descricao",
            //    schema: "DECORAPHP",
            //    table: "MH_CATEGORIAS",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true,
            //    defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Descricao",
            //    schema: "DECORAPHP",
            //    table: "MH_CATEGORIAS");
        }
    }
}
