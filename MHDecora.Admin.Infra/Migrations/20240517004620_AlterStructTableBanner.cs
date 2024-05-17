using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHDecora.Admin.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterStructTableBanner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Id",
                schema: "DECORAPHP",
                table: "MH_BANNERS",
                type: "RAW(900)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "RAW(16)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "DECORAPHP",
                table: "MH_BANNERS",
                type: "RAW(16)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "RAW(900)");
        }
    }
}
