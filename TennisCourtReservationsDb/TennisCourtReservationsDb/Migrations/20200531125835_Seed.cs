using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisCourtReservationsDb.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "Firstname", "Lastname" },
                values: new object[] { 1, 66, "Hansi", "Huber" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "Firstname", "Lastname" },
                values: new object[] { 2, 23, "Fritzi", "Müller" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "Firstname", "Lastname" },
                values: new object[] { 3, 31, "Susi", "Berger" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "DayOfWeek", "Hour", "PersonId", "Week" },
                values: new object[,]
                {
                    { 1, 1, 12, 1, 22 },
                    { 4, 2, 11, 1, 22 },
                    { 3, 2, 14, 2, 22 },
                    { 2, 4, 12, 3, 22 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
