using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Foods",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Foods",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Foods");
        }
    }
}
