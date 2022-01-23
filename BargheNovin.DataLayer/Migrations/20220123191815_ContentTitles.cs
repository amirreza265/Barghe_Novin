using Microsoft.EntityFrameworkCore.Migrations;

namespace BargheNovin.DataLayer.Migrations
{
    public partial class ContentTitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentTitle",
                table: "ImageContents",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentTitle",
                table: "Contents",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentTitle",
                table: "ImageContents");

            migrationBuilder.DropColumn(
                name: "ContentTitle",
                table: "Contents");
        }
    }
}
