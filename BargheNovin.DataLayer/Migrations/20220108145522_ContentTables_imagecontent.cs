using Microsoft.EntityFrameworkCore.Migrations;

namespace BargheNovin.DataLayer.Migrations
{
    public partial class ContentTables_imagecontent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageContents",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageContentPageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageContents", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ImageContents_PageContents_PageContentPageId",
                        column: x => x.PageContentPageId,
                        principalTable: "PageContents",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageContents_PageContentPageId",
                table: "ImageContents",
                column: "PageContentPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageContents");
        }
    }
}
