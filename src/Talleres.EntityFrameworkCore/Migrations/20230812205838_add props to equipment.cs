using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talleres.Migrations
{
    /// <inheritdoc />
    public partial class addpropstoequipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "Taller",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Taller",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                schema: "Taller",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Taller",
                table: "Equipment");
        }
    }
}
