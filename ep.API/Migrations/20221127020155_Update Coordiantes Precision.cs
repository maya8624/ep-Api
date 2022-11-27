using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ep.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoordiantesPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Business",
                type: "decimal(9,7)",
                precision: 9,
                scale: 7,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Business",
                type: "decimal(8,7)",
                precision: 8,
                scale: 7,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,6)",
                oldPrecision: 8,
                oldScale: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Business",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,7)",
                oldPrecision: 9,
                oldScale: 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Business",
                type: "decimal(8,6)",
                precision: 8,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,7)",
                oldPrecision: 8,
                oldScale: 7);
        }
    }
}
