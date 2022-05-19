using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "TblBoon");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TblBoon",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TblBoon");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "TblBoon",
                nullable: false,
                defaultValue: 0);
        }
    }
}
