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

            migrationBuilder.CreateTable(
                name: "MH_BANNERS",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ordem = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_BANNERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MH_CATEGORIAS",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_CATEGORIAS", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "MH_QUEMSOMOS",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_QUEMSOMOS", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "MH_MONTAGEM",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CaminhoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CaminhoImagem2 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CaminhoImagem3 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CaminhoImagem4 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TextoImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LinkBotao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MontagemDestaque = table.Column<bool>(type: "NUMBER(1)", nullable: false, defaultValue: false),
                    TagId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CategoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_MONTAGEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MH_MONTAGEM_MH_CATEGORIAS_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "DECORAPHP",
                        principalTable: "MH_CATEGORIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MH_MONTAGEM_TAGS",
                columns: table => new
                {
                    MontagemId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TagId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_MONTAGEM_TAGS", x => new { x.MontagemId, x.TagId });
                    table.ForeignKey(
                        name: "FK_MH_MONTAGEM_TAGS_MH_MONTAGEM_MontagemId",
                        column: x => x.MontagemId,
                        principalSchema: "DECORAPHP",
                        principalTable: "MH_MONTAGEM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MH_MONTAGEM_TAGS_MH_TAGS_TagId",
                        column: x => x.TagId,
                        principalSchema: "DECORAPHP",
                        principalTable: "MH_TAGS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MH_MONTAGEM_CategoriaId",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_MH_MONTAGEM_TAGS_TagId",
                table: "MH_MONTAGEM_TAGS",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MH_BANNERS",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_CONTATO",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_MONTAGEM_TAGS");

            migrationBuilder.DropTable(
                name: "MH_QUEMSOMOS",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_TEMA",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_MONTAGEM",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_TAGS",
                schema: "DECORAPHP");

            migrationBuilder.DropTable(
                name: "MH_CATEGORIAS",
                schema: "DECORAPHP");
        }
    }
}
