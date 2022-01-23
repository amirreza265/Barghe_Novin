using Microsoft.EntityFrameworkCore.Migrations;

namespace BargheNovin.DataLayer.Migrations
{
    public partial class PageDisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "PageContents",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PageContents_DisplayName",
                table: "PageContents",
                column: "DisplayName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageContents_DisplayName",
                table: "PageContents");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "PageContents");
        }
    }
}
