using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Név = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tápérték = table.Column<int>(type: "int", nullable: false),
                    Kategória = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ár = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
