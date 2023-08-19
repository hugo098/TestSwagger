using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CititesManager.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CityNameRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: new Guid("445a009d-48b4-459d-a3b4-080e5884663e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: new Guid("cee2e14a-c71b-44ae-9d66-f408fbecddb5"));

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { new Guid("7a0c5c7f-91ba-4cbd-b896-be9febc1cab8"), "New York" },
                    { new Guid("f19698aa-e15a-48a4-9284-4a9d9e54eadc"), "Asuncion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: new Guid("7a0c5c7f-91ba-4cbd-b896-be9febc1cab8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: new Guid("f19698aa-e15a-48a4-9284-4a9d9e54eadc"));

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { new Guid("445a009d-48b4-459d-a3b4-080e5884663e"), "Asuncion" },
                    { new Guid("cee2e14a-c71b-44ae-9d66-f408fbecddb5"), "New York" }
                });
        }
    }
}
