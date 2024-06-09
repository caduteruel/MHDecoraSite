using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TableOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "MH_ORCAMENTO",
            schema: "DECORAPHP",
            columns: table => new
            {
                Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                    .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                AindaNaoDefiniODia = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                MaisInformacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MH_ORCAMENTO", x => x.Id);
            });

            migrationBuilder.RenameTable(
                name: "MH_ORCAMENTO",
                newName: "MH_ORCAMENTO",
                newSchema: "DECORAPHP");

            migrationBuilder.RenameColumn(
                name: "MaisInformacao",
                schema: "DECORAPHP",
                table: "MH_ORCAMENTO",
                newName: "MaisInformacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MH_ORCAMENTO");

            migrationBuilder.RenameTable(
                name: "MH_ORCAMENTO",
                schema: "DECORAPHP",
                newName: "MH_ORCAMENTO");

            migrationBuilder.RenameColumn(
                name: "MaisInformacoes",
                table: "MH_ORCAMENTO",
                newName: "MaisInformacao");
        }
    }
}
