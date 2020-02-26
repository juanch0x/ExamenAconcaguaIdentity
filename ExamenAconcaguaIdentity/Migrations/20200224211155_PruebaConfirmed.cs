using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class PruebaConfirmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e466ce6-e6e6-46b3-9592-72adda874d88");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13506824-307a-4b9e-a432-356d5c837e83", "2c0abe99-1d96-43a4-b11b-2fb0847c6176", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13506824-307a-4b9e-a432-356d5c837e83");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e466ce6-e6e6-46b3-9592-72adda874d88", "b7d719af-5cc4-4b17-9940-b62496cd9b66", "Admin", "ADMIN" });
        }
    }
}
