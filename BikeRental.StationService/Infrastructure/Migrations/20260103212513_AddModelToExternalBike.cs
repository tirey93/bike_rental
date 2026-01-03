using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.StationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddModelToExternalBike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "ExternalBikes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "ExternalBikes");
        }
    }
}
