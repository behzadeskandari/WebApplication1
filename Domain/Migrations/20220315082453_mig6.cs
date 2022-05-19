using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValidBoonPerDay",
                table: "TblSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "spID",
                table: "TblProducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblSpical",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSpical", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProducts_spID",
                table: "TblProducts",
                column: "spID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblSpical_spID",
                table: "TblProducts",
                column: "spID",
                principalTable: "TblSpical",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblSpical_spID",
                table: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblSpical");

            migrationBuilder.DropIndex(
                name: "IX_TblProducts_spID",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "ValidBoonPerDay",
                table: "TblSettings");

            migrationBuilder.DropColumn(
                name: "spID",
                table: "TblProducts");
        }
    }
}
