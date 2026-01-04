using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.BikeService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalBikeAtStations_Station_StationId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Station",
                table: "Station");

            migrationBuilder.RenameTable(
                name: "Station",
                newName: "Stations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stations",
                table: "Stations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalBikeAtStations_Stations_StationId",
                table: "ExternalBikeAtStations",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalBikeAtStations_Stations_StationId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stations",
                table: "Stations");

            migrationBuilder.RenameTable(
                name: "Stations",
                newName: "Station");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Station",
                table: "Station",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalBikeAtStations_Station_StationId",
                table: "ExternalBikeAtStations",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
