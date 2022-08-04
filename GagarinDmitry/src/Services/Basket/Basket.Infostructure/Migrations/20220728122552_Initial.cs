using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Basket.Infostructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    Seat = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateOfPurchase", "Price", "Row", "Seat", "SessionId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 7, 28, 15, 25, 52, 789, DateTimeKind.Unspecified).AddTicks(3818), new TimeSpan(0, 3, 0, 0, 0)), 212, 1, 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2022, 7, 28, 15, 25, 52, 789, DateTimeKind.Unspecified).AddTicks(3852), new TimeSpan(0, 3, 0, 0, 0)), 212, 1, 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
