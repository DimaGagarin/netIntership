using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infostructure.Migrations
{
    public partial class somedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "City", "Country", "PhoneNumber", "Сapacity" },
                values: new object[] { 1, "sd", "dsa", "dsaf", "sadf", 2 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CinemaId", "StartTime", "TicketPrice", "Title" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2022, 7, 27, 15, 19, 26, 465, DateTimeKind.Unspecified).AddTicks(3119), new TimeSpan(0, 3, 0, 0, 0)), 12m, "asd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
