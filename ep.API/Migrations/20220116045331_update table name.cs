using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIePager.Migrations
{
    public partial class updatetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageHitories_Messages_MessageId",
                table: "MessageHitories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageHitories",
                table: "MessageHitories");

            migrationBuilder.RenameTable(
                name: "MessageHitories",
                newName: "MessageHistories");

            migrationBuilder.RenameIndex(
                name: "IX_MessageHitories_MessageId",
                table: "MessageHistories",
                newName: "IX_MessageHistories_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageHistories",
                table: "MessageHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageHistories_Messages_MessageId",
                table: "MessageHistories",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageHistories_Messages_MessageId",
                table: "MessageHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageHistories",
                table: "MessageHistories");

            migrationBuilder.RenameTable(
                name: "MessageHistories",
                newName: "MessageHitories");

            migrationBuilder.RenameIndex(
                name: "IX_MessageHistories_MessageId",
                table: "MessageHitories",
                newName: "IX_MessageHitories_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageHitories",
                table: "MessageHitories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageHitories_Messages_MessageId",
                table: "MessageHitories",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");
        }
    }
}
