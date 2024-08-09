using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wandermate.Migrations
{
    /// <inheritdoc />
    public partial class diamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Hotelinfo",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Hotelinfo");
        }
    }
}
