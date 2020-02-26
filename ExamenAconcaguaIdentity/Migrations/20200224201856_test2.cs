using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ed60406-853a-441f-a451-d4884df87b4a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63a51976-3d67-42d6-acfe-8ad7c5751d72", "bb28021e-55ed-419c-b28b-e759c69d21b4", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a51976-3d67-42d6-acfe-8ad7c5751d72");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ed60406-853a-441f-a451-d4884df87b4a", "2cfff43a-6480-4c6f-bfc8-ca25ba390542", "Admin", "ADMIN" });
        }
    }
}
