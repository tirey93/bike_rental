using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.StationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToBikeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BikeExternalId",
                table: "BikesAtStation");

            migrationBuilder.AddColumn<int>(
                name: "BikeId",
                table: "BikesAtStation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BikesAtStation_BikeId",
                table: "BikesAtStation",
                column: "BikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BikesAtStation_ExternalBikes_BikeId",
                table: "BikesAtStation",
                column: "BikeId",
                principalTable: "ExternalBikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BikesAtStation_ExternalBikes_BikeId",
                table: "BikesAtStation");

            migrationBuilder.DropIndex(
                name: "IX_BikesAtStation_BikeId",
                table: "BikesAtStation");

            migrationBuilder.DropColumn(
                name: "BikeId",
                table: "BikesAtStation");

            migrationBuilder.AddColumn<Guid>(
                name: "BikeExternalId",
                table: "BikesAtStation",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
