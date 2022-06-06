using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class slide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sildes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureAlte = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureTitel = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BtnText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRemovd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sildes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sildes");
        }
    }
}
