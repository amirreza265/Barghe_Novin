using Microsoft.EntityFrameworkCore.Migrations;

namespace BargheNovin.DataLayer.Migrations
{
    public partial class Portfolio_IsDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Portfolio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCategories_FilterName",
                table: "PortfolioCategories",
                column: "FilterName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PortfolioCategories_FilterName",
                table: "PortfolioCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Portfolio");
        }
    }
}
