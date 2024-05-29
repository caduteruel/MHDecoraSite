using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Contato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MH_CONTATO",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HorarioAtendimento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_CONTATO", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MH_CONTATO",
                schema: "DECORAPHP");
        }
    }
}
