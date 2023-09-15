using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transport.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedEntityColumnsNewReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);
        }
    }
}
