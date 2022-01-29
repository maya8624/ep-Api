using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIePager.Migrations
{
    public partial class CreateForeignKeyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ShopId",
                table: "Visitors",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ShopId",
                table: "Messages",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Shops_ShopId",
                table: "Messages",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Shops_ShopId",
                table: "Visitors",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Shops_ShopId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Shops_ShopId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_ShopId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ShopId",
                table: "Messages");
        }
    }
}
