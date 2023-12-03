using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talleres.Migrations
{
    /// <inheritdoc />
    public partial class editlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                schema: "Taller",
                table: "EquipmentCycle");

            migrationBuilder.DropColumn(
                name: "To",
                schema: "Taller",
                table: "EquipmentCycle");

            migrationBuilder.AddColumn<int>(
                name: "HorometerFrom",
                schema: "Taller",
                table: "EquipmentCycle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorometerTo",
                schema: "Taller",
                table: "EquipmentCycle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorometerFrom",
                schema: "Taller",
                table: "EquipmentCycle");

            migrationBuilder.DropColumn(
                name: "HorometerTo",
                schema: "Taller",
                table: "EquipmentCycle");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                schema: "Taller",
                table: "EquipmentCycle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                schema: "Taller",
                table: "EquipmentCycle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
