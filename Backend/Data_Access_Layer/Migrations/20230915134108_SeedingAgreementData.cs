using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class SeedingAgreementData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "CarId", "EndDate", "StartDate", "TotalCost", "UserId" },
                values: new object[] { 1, 21, "2023-09-18", "2023-09-15", 90, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "AgreementId",
                keyValue: 1);
        }
    }
}
