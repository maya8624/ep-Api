using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIePager.Migrations
{
    public partial class fixcolumnordernumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "7",
                table: "Messages",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "5",
                table: "MessageHistories",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Messages",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "MessageHistories",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .Annotation("Relational:ColumnOrder", 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Messages",
                newName: "7");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "MessageHistories",
                newName: "5");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "7",
                table: "Messages",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "5",
                table: "MessageHistories",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .OldAnnotation("Relational:ColumnOrder", 5);
        }
    }
}
