using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Site.Infra.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "DECORAPHP");

            //migrationBuilder.CreateTable(
            //    name: "MH_QUEMSOMOS",
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

            //migrationBuilder.CreateTable(
            //    name: "MH_QUEMSOMOS",
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
            //        table.PrimaryKey("PK_MH_QUEMSOMOS", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MH_TEMA",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        LinkTema = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_TEMA", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MHContato",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Celular = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        HorarioAtendimento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MHContato", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MH_QUEMSOMOS");

            //migrationBuilder.DropTable(
            //    name: "MH_QUEMSOMOS",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropTable(
            //    name: "MH_TEMA");

            //migrationBuilder.DropTable(
            //    name: "MHContato",
            //    schema: "DECORAPHP");
        }
    }
}
