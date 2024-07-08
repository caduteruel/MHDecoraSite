using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Site.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TextoImagemEmpty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MH_QUEMSOMOS");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_MHContato",
            //    schema: "DECORAPHP",
            //    table: "MHContato");

            //migrationBuilder.DropColumn(
            //    name: "Ordem",
            //    schema: "DECORAPHP",
            //    table: "MH_QUEMSOMOS");

            //migrationBuilder.DropColumn(
            //    name: "LinkTema",
            //    table: "MH_TEMA");

            //migrationBuilder.RenameTable(
            //    name: "MH_TEMA",
            //    newName: "MH_TEMA",
            //    newSchema: "DECORAPHP");

            //migrationBuilder.RenameTable(
            //    name: "MHContato",
            //    schema: "DECORAPHP",
            //    newName: "MH_CONTATO",
            //    newSchema: "DECORAPHP");

            //migrationBuilder.AddColumn<string>(
            //    name: "Titulo",
            //    schema: "DECORAPHP",
            //    table: "MH_QUEMSOMOS",
            //    type: "NVARCHAR2(2000)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Tags",
            //    schema: "DECORAPHP",
            //    table: "MH_TEMA",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LinkEndereco",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LinkMapa",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO",
            //    type: "NVARCHAR2(2000)",
            //    nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_MH_CONTATO",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO",
            //    column: "Id");

            //migrationBuilder.CreateTable(
            //    name: "MH_BANNERS",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_BANNERS", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MH_CATEGORIAS",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_CATEGORIAS", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MH_MIDIASOCIAL",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Instagram = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Facebook = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        WhatsApp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_MIDIASOCIAL", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MH_TAGS",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_TAGS", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MH_MONTAGEM",
            //    schema: "DECORAPHP",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        CaminhoImagem2 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        CaminhoImagem3 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        CaminhoImagem4 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        TextoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        LinkBotao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        MontagemDestaque = table.Column<int>(type: "NUMBER(10)", nullable: false),
            //        Tags = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
            //        CategoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_MONTAGEM", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_MH_MONTAGEM_MH_CATEGORIAS_CategoriaId",
            //            column: x => x.CategoriaId,
            //            principalSchema: "DECORAPHP",
            //            principalTable: "MH_CATEGORIAS",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_MH_MONTAGEM_CategoriaId",
            //    schema: "DECORAPHP",
            //    table: "MH_MONTAGEM",
            //    column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MH_BANNERS",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropTable(
            //    name: "MH_MIDIASOCIAL",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropTable(
            //    name: "MH_MONTAGEM",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropTable(
            //    name: "MH_TAGS",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropTable(
            //    name: "MH_CATEGORIAS",
            //    schema: "DECORAPHP");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_MH_CONTATO",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO");

            //migrationBuilder.DropColumn(
            //    name: "Titulo",
            //    schema: "DECORAPHP",
            //    table: "MH_QUEMSOMOS");

            //migrationBuilder.DropColumn(
            //    name: "Tags",
            //    schema: "DECORAPHP",
            //    table: "MH_TEMA");

            //migrationBuilder.DropColumn(
            //    name: "LinkEndereco",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO");

            //migrationBuilder.DropColumn(
            //    name: "LinkMapa",
            //    schema: "DECORAPHP",
            //    table: "MH_CONTATO");

            //migrationBuilder.RenameTable(
            //    name: "MH_TEMA",
            //    schema: "DECORAPHP",
            //    newName: "MH_TEMA");

            //migrationBuilder.RenameTable(
            //    name: "MH_CONTATO",
            //    schema: "DECORAPHP",
            //    newName: "MHContato",
            //    newSchema: "DECORAPHP");

            //migrationBuilder.AddColumn<int>(
            //    name: "Ordem",
            //    schema: "DECORAPHP",
            //    table: "MH_QUEMSOMOS",
            //    type: "NUMBER(10)",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "LinkTema",
            //    table: "MH_TEMA",
            //    type: "NVARCHAR2(2000)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_MHContato",
            //    schema: "DECORAPHP",
            //    table: "MHContato",
            //    column: "Id");

            //migrationBuilder.CreateTable(
            //    name: "MH_QUEMSOMOS",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
            //        CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
            //        Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MH_QUEMSOMOS", x => x.Id);
            //    });
        }
    }
}
