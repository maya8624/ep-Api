using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ep.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAccessTokenAddTokenExpires : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "UserTokens");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TokenExpires",
                table: "UserTokens",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenExpires",
                table: "UserTokens");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
