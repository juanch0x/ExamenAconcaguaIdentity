using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class Aver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe91cf81-6439-476c-a360-dab7597548ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e466ce6-e6e6-46b3-9592-72adda874d88", "b7d719af-5cc4-4b17-9940-b62496cd9b66", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e466ce6-e6e6-46b3-9592-72adda874d88");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe91cf81-6439-476c-a360-dab7597548ce", "76b066b7-f07a-4211-8d06-2afd953bb1cc", "Admin", "ADMIN" });
        }
    }
}
