using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TableMidiasSociais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LinkBotao",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "DECORAPHP",
                table: "MH_BANNERS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.CreateTable(
                name: "MH_MIDIASOCIAL",
                schema: "DECORAPHP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Instagram = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Facebook = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    WhatsApp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MH_MIDIASOCIAL", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MH_MIDIASOCIAL",
                schema: "DECORAPHP");

            migrationBuilder.AlterColumn<string>(
                name: "LinkBotao",
                schema: "DECORAPHP",
                table: "MH_MONTAGEM",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "DECORAPHP",
                table: "MH_BANNERS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);
        }
    }
}
