using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DECORAPHP");

            //migrationBuilder.CreateTable(
            //    name: "MH_BANNERS",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Ordem = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_BANNERS", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MH_MONTAGEM",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        TextoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        LinkBotao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_MONTAGEM", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MH_QUEMSOMOS",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_QUEMSOMOS", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MH_BANNERS",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropTable(
            //    name: "MH_MONTAGEM",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropTable(
            //    name: "MH_QUEMSOMOS",
            //    schema: "DECORAPHP");
        }
    }
}
