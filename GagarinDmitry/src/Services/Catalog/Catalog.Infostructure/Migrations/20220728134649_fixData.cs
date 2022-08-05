using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infostructure.Migrations
{
    public partial class fixData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Сapacity",
                table: "Cinemas");

            migrationBuilder.AddColumn<int>(
                name: "FilmType",
                table: "Sessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreeSeats",
                table: "Sessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cinemas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "Country", "PhoneNumber", "Title" },
                values: new object[] { "ul. Kosmonavtov 35-11", "Mogilev", "Belarus", "+375228888888", "October" });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FilmType", "FreeSeats", "StartTime" },
                values: new object[] { 1, 50, new DateTimeOffset(new DateTime(2022, 7, 28, 16, 46, 48, 913, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CinemaId", "FilmType", "FreeSeats", "StartTime" },
                values: new object[] { 2, 1, 2, 50, new DateTimeOffset(new DateTime(2022, 7, 28, 16, 46, 48, 913, DateTimeKind.Unspecified).AddTicks(378), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FilmType",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "FreeSeats",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cinemas");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Sessions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Сapacity",
                table: "Cinemas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "Country", "PhoneNumber", "Сapacity" },
                values: new object[] { "sd", "dsa", "dsaf", "sadf", 2 });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StartTime", "TicketPrice", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 27, 15, 19, 26, 465, DateTimeKind.Unspecified).AddTicks(3119), new TimeSpan(0, 3, 0, 0, 0)), 12m, "asd" });
        }
    }
}
