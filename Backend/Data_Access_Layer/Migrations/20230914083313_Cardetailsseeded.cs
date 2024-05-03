using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class Cardetailsseeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Available", "Maker", "Model", "RentalPrice" },
                values: new object[,]
                {
                    { 10, "Yes", "Maruti Suzuki", "Maruti Suzuki Swift", "50$" },
                    { 11, "Yes", "Maruti Suzuki", "Maruti Suzuki Vitara Brezza", "60$" },
                    { 20, "Yes", "Ford", "Ford Mustang", "100$" },
                    { 21, "Yes", "Ford", "Ford Escape", "80$" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
