using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Data.Migrations
{
    public partial class MoreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SerialNumber",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingTypeId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductWeight = table.Column<float>(type: "real", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderStatus_OrderStatusId",
                table: "Order",
                column: "OrderStatusId",
                principalTable: "OrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentType_PaymentTypeId",
                table: "Order",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShippingType_ShippingTypeId",
                table: "Order",
                column: "ShippingTypeId",
                principalTable: "ShippingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderStatus_OrderStatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentType_PaymentTypeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShippingType_ShippingTypeId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShippingType");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingTypeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingTypeId",
                table: "Order");
        }
    }
}
