using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class CantidadDeCuotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13506824-307a-4b9e-a432-356d5c837e83");

            migrationBuilder.AddColumn<int>(
                name: "Cuotas",
                table: "Prestamos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3c3bab7-edec-4444-a56b-9718361d3160", "69c3d321-acb5-4bd6-a11e-720644badc16", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3c3bab7-edec-4444-a56b-9718361d3160");

            migrationBuilder.DropColumn(
                name: "Cuotas",
                table: "Prestamos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13506824-307a-4b9e-a432-356d5c837e83", "2c0abe99-1d96-43a4-b11b-2fb0847c6176", "Admin", "ADMIN" });
        }
    }
}
