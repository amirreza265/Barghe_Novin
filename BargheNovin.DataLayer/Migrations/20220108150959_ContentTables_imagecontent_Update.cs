using Microsoft.EntityFrameworkCore.Migrations;

namespace BargheNovin.DataLayer.Migrations
{
    public partial class ContentTables_imagecontent_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "ImageContents",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageKey",
                table: "ImageContents",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ImageContents_ImageKey",
                table: "ImageContents",
                column: "ImageKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageContents_ImageKey",
                table: "ImageContents");

            migrationBuilder.DropColumn(
                name: "ImageKey",
                table: "ImageContents");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "ImageContents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
