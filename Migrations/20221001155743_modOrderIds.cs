using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Migrations
{
    public partial class modOrderIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingTypeId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingTypeId",
                table: "Order",
                column: "ShippingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingTypeId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order",
                column: "PaymentTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingTypeId",
                table: "Order",
                column: "ShippingTypeId",
                unique: true);
        }
    }
}
