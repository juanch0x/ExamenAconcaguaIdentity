using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class secambioaoffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37ad28e5-4719-4905-809b-554207147f9e");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "FechaTentativaDeEntrega",
                table: "Prestamos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "AutorizacionDelPrestamo",
                table: "Prestamos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a869f341-bfd9-4d9b-b4b3-8512a513cdea", "54d7725f-3f88-4baf-a51e-97f889fc9b34", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a869f341-bfd9-4d9b-b4b3-8512a513cdea");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaTentativaDeEntrega",
                table: "Prestamos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AutorizacionDelPrestamo",
                table: "Prestamos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37ad28e5-4719-4905-809b-554207147f9e", "1a433106-4140-4c4b-b608-7e88fc68e497", "Admin", "ADMIN" });
        }
    }
}
