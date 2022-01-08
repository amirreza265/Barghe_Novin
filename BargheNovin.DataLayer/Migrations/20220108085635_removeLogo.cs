using Microsoft.EntityFrameworkCore.Migrations;

namespace BargheNovin.DataLayer.Migrations
{
    public partial class removeLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogoFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogoFiles",
                columns: table => new
                {
                    LogoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooterLogo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MainLogo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SmallLogo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogoFiles", x => x.LogoId);
                });
        }
    }
}
