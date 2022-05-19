using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleID",
                table: "TblPropertis",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblPropertiseTitle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    TopicID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPropertiseTitle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TblPropertiseTitle_TblTopic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "TblTopic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPropertis_TitleID",
                table: "TblPropertis",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_TblPropertiseTitle_TopicID",
                table: "TblPropertiseTitle",
                column: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPropertis_TblPropertiseTitle_TitleID",
                table: "TblPropertis",
                column: "TitleID",
                principalTable: "TblPropertiseTitle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPropertis_TblPropertiseTitle_TitleID",
                table: "TblPropertis");

            migrationBuilder.DropTable(
                name: "TblPropertiseTitle");

            migrationBuilder.DropIndex(
                name: "IX_TblPropertis_TitleID",
                table: "TblPropertis");

            migrationBuilder.DropColumn(
                name: "TitleID",
                table: "TblPropertis");
        }
    }
}
