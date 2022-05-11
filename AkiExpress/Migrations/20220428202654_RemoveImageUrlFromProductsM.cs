using Microsoft.EntityFrameworkCore.Migrations;

namespace AkiExpress.Migrations
{
    public partial class RemoveImageUrlFromProductsM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Images",
                newName: "Thumbnail");

            migrationBuilder.AddColumn<string>(
                name: "Image01",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image02",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image03",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image04",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image05",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image01",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Image02",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Image03",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Image04",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Image05",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Images",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
