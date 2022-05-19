using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAsks_AspNetUsers_ApplicationUserId",
                table: "TblAsks");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPropertis_TblTopic_TopicID",
                table: "TblPropertis");

            migrationBuilder.DropIndex(
                name: "IX_TblPropertis_TopicID",
                table: "TblPropertis");

            migrationBuilder.DropColumn(
                name: "TopicID",
                table: "TblPropertis");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "TblAsks",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_TblAsks_ApplicationUserId",
                table: "TblAsks",
                newName: "IX_TblAsks_UserID");

            migrationBuilder.AddColumn<bool>(
                name: "OnlyShowConfirmedComment",
                table: "TblSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAsks_AspNetUsers_UserID",
                table: "TblAsks",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAsks_AspNetUsers_UserID",
                table: "TblAsks");

            migrationBuilder.DropColumn(
                name: "OnlyShowConfirmedComment",
                table: "TblSettings");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "TblAsks",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TblAsks_UserID",
                table: "TblAsks",
                newName: "IX_TblAsks_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "TopicID",
                table: "TblPropertis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblPropertis_TopicID",
                table: "TblPropertis",
                column: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAsks_AspNetUsers_ApplicationUserId",
                table: "TblAsks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPropertis_TblTopic_TopicID",
                table: "TblPropertis",
                column: "TopicID",
                principalTable: "TblTopic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
