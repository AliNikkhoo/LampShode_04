using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class @is : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fake",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "jihfywf",
                table: "ProductCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fake",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "jihfywf",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
