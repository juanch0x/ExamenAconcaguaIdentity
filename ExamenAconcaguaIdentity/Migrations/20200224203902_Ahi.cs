using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class Ahi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c15f6ae8-9692-4311-8b8b-132d8e2fcdb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe91cf81-6439-476c-a360-dab7597548ce", "76b066b7-f07a-4211-8d06-2afd953bb1cc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe91cf81-6439-476c-a360-dab7597548ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c15f6ae8-9692-4311-8b8b-132d8e2fcdb6", "cb6c1c58-d5a1-4315-9cd2-1435e37c06db", "Admin", "ADMIN" });
        }
    }
}
