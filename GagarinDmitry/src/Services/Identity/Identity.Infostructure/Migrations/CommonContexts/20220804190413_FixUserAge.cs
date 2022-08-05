using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infostructure.Migrations.CommmonContexts
{
    public partial class FixUserAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Age",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Age",
                table: "AspNetUsers",
                column: "Age",
                unique: true);
        }
    }
}
