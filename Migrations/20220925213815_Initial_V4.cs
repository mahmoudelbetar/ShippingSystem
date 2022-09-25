using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Migrations
{
    public partial class Initial_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_City_GovernorateId",
                table: "City",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Governorate_GovernorateId",
                table: "City",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Governorate_GovernorateId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_GovernorateId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "City");
        }
    }
}
