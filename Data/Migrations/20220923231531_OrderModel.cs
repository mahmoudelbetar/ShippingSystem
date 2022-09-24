using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Data.Migrations
{
    public partial class OrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTypes = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Governorates = table.Column<int>(type: "int", nullable: false),
                    Cities = table.Column<int>(type: "int", nullable: false),
                    StreetAndVillage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVillage = table.Column<bool>(type: "bit", nullable: true),
                    Branches = table.Column<int>(type: "int", nullable: false),
                    OrderCost = table.Column<float>(type: "real", nullable: false),
                    TotalWeight = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MerchantPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
