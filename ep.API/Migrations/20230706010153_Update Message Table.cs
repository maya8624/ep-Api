using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ep.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Messages",
                newName: "MessageType");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "MessageSentOn",
                table: "Messages",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageSentOn",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Messages",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "MessageType",
                table: "Messages",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
