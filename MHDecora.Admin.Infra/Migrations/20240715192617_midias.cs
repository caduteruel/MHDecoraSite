using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class midias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleAds",
                schema: "DECORAPHP",
                table: "MH_MIDIASOCIAL",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GoogleAnalytics",
                schema: "DECORAPHP",
                table: "MH_MIDIASOCIAL",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                schema: "DECORAPHP",
                table: "MH_MIDIASOCIAL",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleAds",
                schema: "DECORAPHP",
                table: "MH_MIDIASOCIAL");

            migrationBuilder.DropColumn(
                name: "GoogleAnalytics",
                schema: "DECORAPHP",
                table: "MH_MIDIASOCIAL");

            migrationBuilder.DropColumn(
                name: "Meta",
                schema: "DECORAPHP",
                table: "MH_MIDIASOCIAL");
        }
    }
}
