using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ep.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameTokentoAccessToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "UserTokens",
                newName: "AccessToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccessToken",
                table: "UserTokens",
                newName: "Token");
        }
    }
}
