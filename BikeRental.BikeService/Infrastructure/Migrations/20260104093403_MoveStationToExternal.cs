using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.BikeService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveStationToExternal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropColumn(
                name: "StationExternalId",
                table: "ExternalBikeAtStations");

            migrationBuilder.AlterColumn<int>(
                name: "BikeId",
                table: "ExternalBikeAtStations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "ExternalBikeAtStations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalBikeAtStations_StationId",
                table: "ExternalBikeAtStations",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalBikeAtStations_Station_StationId",
                table: "ExternalBikeAtStations",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalBikeAtStations_Station_StationId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropIndex(
                name: "IX_ExternalBikeAtStations_StationId",
                table: "ExternalBikeAtStations");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "ExternalBikeAtStations");

            migrationBuilder.AlterColumn<int>(
                name: "BikeId",
                table: "ExternalBikeAtStations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<Guid>(
                name: "StationExternalId",
                table: "ExternalBikeAtStations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalBikeAtStations_Bikes_BikeId",
                table: "ExternalBikeAtStations",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id");
        }
    }
}
