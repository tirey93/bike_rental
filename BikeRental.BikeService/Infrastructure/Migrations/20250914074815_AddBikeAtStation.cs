using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.BikeService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBikeAtStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeAtStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BikeId = table.Column<int>(type: "INTEGER", nullable: true),
                    StationExternalId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeAtStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BikeAtStations_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikeAtStations_BikeId",
                table: "BikeAtStations",
                column: "BikeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeAtStations");
        }
    }
}
