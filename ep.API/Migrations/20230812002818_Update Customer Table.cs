using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ep.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetail_RequestLimit_RequestLimitId",
                table: "RequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetail_Users_UserId",
                table: "RequestDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestDetail",
                table: "RequestDetail");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "RequestDetail",
                newName: "RequestDetails");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetail_UserId",
                table: "RequestDetails",
                newName: "IX_RequestDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetail_RequestLimitId",
                table: "RequestDetails",
                newName: "IX_RequestDetails_RequestLimitId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateVisited",
                table: "Customers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Customers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestDetails",
                table: "RequestDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_RequestLimit_RequestLimitId",
                table: "RequestDetails",
                column: "RequestLimitId",
                principalTable: "RequestLimit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_Users_UserId",
                table: "RequestDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_RequestLimit_RequestLimitId",
                table: "RequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_Users_UserId",
                table: "RequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestDetails",
                table: "RequestDetails");

            migrationBuilder.DropColumn(
                name: "DateVisited",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "RequestDetails",
                newName: "RequestDetail");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetails_UserId",
                table: "RequestDetail",
                newName: "IX_RequestDetail_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestDetails_RequestLimitId",
                table: "RequestDetail",
                newName: "IX_RequestDetail_RequestLimitId");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestDetail",
                table: "RequestDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetail_RequestLimit_RequestLimitId",
                table: "RequestDetail",
                column: "RequestLimitId",
                principalTable: "RequestLimit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetail_Users_UserId",
                table: "RequestDetail",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
