using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.BikeService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBindToStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropIndex(
                name: "IX_ExternalBikeAtStations_BikeId",
                table: "ExternalBikeAtStations");

            migrationBuilder.AddColumn<int>(
                name: "BikeAtStationId",
                table: "Bikes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_BikeAtStationId",
                table: "Bikes",
                column: "BikeAtStationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_ExternalBikeAtStations_BikeAtStationId",
                table: "Bikes",
                column: "BikeAtStationId",
                principalTable: "ExternalBikeAtStations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_ExternalBikeAtStations_BikeAtStationId",
                table: "Bikes");

            migrationBuilder.DropIndex(
                name: "IX_Bikes_BikeAtStationId",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "BikeAtStationId",
                table: "Bikes");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalBikeAtStations_BikeId",
                table: "ExternalBikeAtStations",
                column: "BikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
