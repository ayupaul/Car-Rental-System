using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class availableremovedfromcar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Available",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 10,
                column: "Available",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 11,
                column: "Available",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 20,
                column: "Available",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 21,
                column: "Available",
                value: "Yes");
        }
    }
}
