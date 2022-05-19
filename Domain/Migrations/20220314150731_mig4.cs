using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFavo_TblProducts_ProductID",
                table: "TblFavo");

            migrationBuilder.DropForeignKey(
                name: "FK_TblFavo_AspNetUsers_UserID",
                table: "TblFavo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblFavo",
                table: "TblFavo");

            migrationBuilder.RenameTable(
                name: "TblFavo",
                newName: "TblFavos");

            migrationBuilder.RenameIndex(
                name: "IX_TblFavo_UserID",
                table: "TblFavos",
                newName: "IX_TblFavos_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_TblFavo_ProductID",
                table: "TblFavos",
                newName: "IX_TblFavos_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblFavos",
                table: "TblFavos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFavos_TblProducts_ProductID",
                table: "TblFavos",
                column: "ProductID",
                principalTable: "TblProducts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblFavos_AspNetUsers_UserID",
                table: "TblFavos",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFavos_TblProducts_ProductID",
                table: "TblFavos");

            migrationBuilder.DropForeignKey(
                name: "FK_TblFavos_AspNetUsers_UserID",
                table: "TblFavos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblFavos",
                table: "TblFavos");

            migrationBuilder.RenameTable(
                name: "TblFavos",
                newName: "TblFavo");

            migrationBuilder.RenameIndex(
                name: "IX_TblFavos_UserID",
                table: "TblFavo",
                newName: "IX_TblFavo_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_TblFavos_ProductID",
                table: "TblFavo",
                newName: "IX_TblFavo_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblFavo",
                table: "TblFavo",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFavo_TblProducts_ProductID",
                table: "TblFavo",
                column: "ProductID",
                principalTable: "TblProducts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblFavo_AspNetUsers_UserID",
                table: "TblFavo",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
