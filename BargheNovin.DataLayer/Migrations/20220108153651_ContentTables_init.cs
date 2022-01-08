﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BargheNovin.DataLayer.Migrations
{
    public partial class ContentTables_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentNames",
                columns: table => new
                {
                    ContentNameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentNames", x => x.ContentNameId);
                });

            migrationBuilder.CreateTable(
                name: "PageContents",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContents", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentNameId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    ContentHtml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Contents_ContentNames_ContentNameId",
                        column: x => x.ContentNameId,
                        principalTable: "ContentNames",
                        principalColumn: "ContentNameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_PageContents_PageId",
                        column: x => x.PageId,
                        principalTable: "PageContents",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageContents",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImageKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageContents", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ImageContents_PageContents_PageId",
                        column: x => x.PageId,
                        principalTable: "PageContents",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentNames_Name",
                table: "ContentNames",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ContentNameId",
                table: "Contents",
                column: "ContentNameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_PageId",
                table: "Contents",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageContents_ImageKey",
                table: "ImageContents",
                column: "ImageKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageContents_PageId",
                table: "ImageContents",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageContents_PageName",
                table: "PageContents",
                column: "PageName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "ImageContents");

            migrationBuilder.DropTable(
                name: "ContentNames");

            migrationBuilder.DropTable(
                name: "PageContents");
        }
    }
}
