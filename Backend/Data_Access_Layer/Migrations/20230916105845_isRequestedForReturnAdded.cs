using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class isRequestedForReturnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "AgreementId",
                keyValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestedForReturn",
                table: "Agreements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequestedForReturn",
                table: "Agreements");

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "CarId", "EndDate", "StartDate", "TotalCost", "UserId" },
                values: new object[] { 1, 21, "2023-09-18", "2023-09-15", 90, 1 });
        }
    }
}
