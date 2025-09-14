using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.BikeService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameBikeAtStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BikeAtStations_Bikes_BikeId",
                table: "BikeAtStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BikeAtStations",
                table: "BikeAtStations");

            migrationBuilder.RenameTable(
                name: "BikeAtStations",
                newName: "ExternalBikeAtStations");

            migrationBuilder.RenameIndex(
                name: "IX_BikeAtStations_BikeId",
                table: "ExternalBikeAtStations",
                newName: "IX_ExternalBikeAtStations_BikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalBikeAtStations",
                table: "ExternalBikeAtStations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalBikeAtStations",
                table: "ExternalBikeAtStations");

            migrationBuilder.RenameTable(
                name: "ExternalBikeAtStations",
                newName: "BikeAtStations");

            migrationBuilder.RenameIndex(
                name: "IX_ExternalBikeAtStations_BikeId",
                table: "BikeAtStations",
                newName: "IX_BikeAtStations_BikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BikeAtStations",
                table: "BikeAtStations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BikeAtStations_Bikes_BikeId",
                table: "BikeAtStations",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id");
        }
    }
}
