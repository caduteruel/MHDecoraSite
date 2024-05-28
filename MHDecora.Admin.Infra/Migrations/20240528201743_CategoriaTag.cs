using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MH_CATEGORIAS",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_CATEGORIAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MH_TAGS",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_TAGS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MH_TEMA",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LinkTema = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_TEMA", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MH_CATEGORIAS",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_TAGS",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_TEMA",
                schema: "DECORAPHP");
        }
    }
}
