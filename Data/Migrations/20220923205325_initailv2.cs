using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Data.Migrations
{
    public partial class initailv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingCostSetting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingCostSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    DefaultShippingCost = table.Column<float>(type: "real", nullable: false),
                    ExtraWeightCost = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCostSetting", x => x.Id);
                });
        }
    }
}
