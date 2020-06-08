using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisCourtReservationsDb.Migrations
{
    public partial class TableBookingAddPersonFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PersonId",
                table: "Bookings",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Persons_PersonId",
                table: "Bookings",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Persons_PersonId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PersonId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Bookings");
        }
    }
}
