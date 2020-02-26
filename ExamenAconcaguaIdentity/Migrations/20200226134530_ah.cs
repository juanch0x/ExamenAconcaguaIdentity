using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenAconcaguaIdentity.Migrations
{
    public partial class ah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuota_Prestamos_PrestamoId1",
                table: "Cuota");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Solicitantes_SolicitanteId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_SolicitanteId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Cuota_PrestamoId1",
                table: "Cuota");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bdc292c-b2e5-4395-9139-056e763c2277");

            migrationBuilder.DropColumn(
                name: "SolicitanteId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "PrestamoId1",
                table: "Cuota");

            migrationBuilder.AlterColumn<long>(
                name: "PrestamoId",
                table: "Cuota",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37ad28e5-4719-4905-809b-554207147f9e", "1a433106-4140-4c4b-b608-7e88fc68e497", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdSolicitante",
                table: "Prestamos",
                column: "IdSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_PrestamoId",
                table: "Cuota",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuota_Prestamos_PrestamoId",
                table: "Cuota",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Solicitantes_IdSolicitante",
                table: "Prestamos",
                column: "IdSolicitante",
                principalTable: "Solicitantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuota_Prestamos_PrestamoId",
                table: "Cuota");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Solicitantes_IdSolicitante",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_IdSolicitante",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Cuota_PrestamoId",
                table: "Cuota");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37ad28e5-4719-4905-809b-554207147f9e");

            migrationBuilder.AddColumn<long>(
                name: "SolicitanteId",
                table: "Prestamos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrestamoId",
                table: "Cuota",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "PrestamoId1",
                table: "Cuota",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bdc292c-b2e5-4395-9139-056e763c2277", "e7a743b1-938c-41c3-add0-1b41c1383dda", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_SolicitanteId",
                table: "Prestamos",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_PrestamoId1",
                table: "Cuota",
                column: "PrestamoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuota_Prestamos_PrestamoId1",
                table: "Cuota",
                column: "PrestamoId1",
                principalTable: "Prestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Solicitantes_SolicitanteId",
                table: "Prestamos",
                column: "SolicitanteId",
                principalTable: "Solicitantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
