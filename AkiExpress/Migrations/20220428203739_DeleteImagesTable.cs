using Microsoft.EntityFrameworkCore.Migrations;

namespace AkiExpress.Migrations
{
    public partial class DeleteImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Image01",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image02",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image03",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image04",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image05",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image01",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image02",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image03",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image04",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image05",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }
    }
}
