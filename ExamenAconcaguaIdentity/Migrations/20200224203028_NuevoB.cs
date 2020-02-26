using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class NuevoB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a51976-3d67-42d6-acfe-8ad7c5751d72");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c15f6ae8-9692-4311-8b8b-132d8e2fcdb6", "cb6c1c58-d5a1-4315-9cd2-1435e37c06db", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c15f6ae8-9692-4311-8b8b-132d8e2fcdb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63a51976-3d67-42d6-acfe-8ad7c5751d72", "bb28021e-55ed-419c-b28b-e759c69d21b4", "Admin", "ADMIN" });
        }
    }
}
