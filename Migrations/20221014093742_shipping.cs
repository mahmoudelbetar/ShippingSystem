using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.Migrations
{
    public partial class shipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernorateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "WeightSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraWeightCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    NormalCostShipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickUpCostShipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAndVillage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVillage = table.Column<bool>(type: "bit", nullable: false),
                    OrderCost = table.Column<float>(type: "real", nullable: false),
                    TotalWeight = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MerchantPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    ShippingTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    ShippingCost = table.Column<float>(type: "real", nullable: false),
                    RecievedAmount = table.Column<float>(type: "real", nullable: false),
                    PaidShippingValue = table.Column<float>(type: "real", nullable: false),
                    CompanyValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderType_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_ShippingType_ShippingTypeId",
                        column: x => x.ShippingTypeId,
                        principalTable: "ShippingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "782b3d14-193f-41eb-9ee6-073bece4d59a", "71d18d22-856c-4434-8e40-2d63a45102b8", "Merchant", "MERCHANT" },
                    { "98a82c8a-1d51-41c0-b17e-734e7822304d", "fedc935e-ad0f-4761-a006-7983b0646f0f", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2e2f1bdd-7c0b-4854-add0-ab8eec66bc23", 0, "6b4a34d3-3a3b-4814-bca0-48799fa1aa6c", "employee@employee.com", false, true, null, "EMPLOYEE@EMPLOYEE.COM", "EMPLOYEE@EMPLOYEE.COM", "AQAAAAEAACcQAAAAEHSQM1qAccg8Yf1d+msuWKVKCkVWk81L0zXkwZio+rZcaBlz9fCJU+PqKv5SbJbmDQ==", null, false, "HEEVJ4ANMTAJLV57S7ITEKAF2FHIIWBJ", false, "employee@employee.com" },
                    { "acc1915e-bb86-43d6-b34d-78eb7c128a00", 0, "43913d3f-e2df-4956-818c-79506ec9e7d4", "merchant@merchant.com", false, true, null, "MERCHANT@MERCHANT.COM", "MERCHANT@MERCHANT.COM", "AQAAAAEAACcQAAAAECQo2ErqmLbFIrLeowLZXNPN+tNnwS7Ddn8xWxzhzHA+wpuFCjjpuIPh0QNLcJSU3g==", null, false, "2F2KBRLNAE2TKEP3OFJU3N5CBX4QM537", false, "merchant@merchant.com" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "AddingDate", "BranchName", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(7382), "المنوفية", true },
                    { 2, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(7402), "القاهرة", true }
                });

            migrationBuilder.InsertData(
                table: "Governorate",
                columns: new[] { "Id", "GovernorateName", "IsActive" },
                values: new object[,]
                {
                    { 1, "المنوفية", true },
                    { 2, "القاهرة", true }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CountStatus", "StatusName" },
                values: new object[,]
                {
                    { 1, 0, "جديد" },
                    { 2, 0, "قيد الانتظار" },
                    { 3, 0, "تم التسليم للمندوب" },
                    { 4, 0, "تم التسليم" },
                    { 5, 0, "لا يمكن الوصول" },
                    { 6, 0, "تم التأجيل" },
                    { 7, 0, "تم التسليم جزئيا" },
                    { 8, 0, "تم الالغاء من قبل المستلم" },
                    { 9, 0, "تم الرفض مع الدفع" },
                    { 10, 0, "رفض مع سداد جزء" },
                    { 11, 0, "رفض و لم يتم الدفع" }
                });

            migrationBuilder.InsertData(
                table: "OrderType",
                columns: new[] { "Id", "OrderTypeName" },
                values: new object[,]
                {
                    { 1, "التسليم في الفرع" },
                    { 2, "التسليم عند التاجر" }
                });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "واجبة التحصيل" },
                    { 2, "دفع مقدم" },
                    { 3, "طرد مقابل طرد" }
                });

            migrationBuilder.InsertData(
                table: "ShippingType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "شحن عادي" },
                    { 2, "شحن في 24 ساعة" },
                    { 3, "شحن خلال 15 يوم" }
                });

            migrationBuilder.InsertData(
                table: "WeightSetting",
                columns: new[] { "Id", "Cost", "ExtraWeightCost", "Weight" },
                values: new object[] { 1, 5m, 5m, 10m });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName", "GovernorateId", "NormalCostShipping", "PickUpCostShipping" },
                values: new object[] { 1, "شبين الكوم", 1, 10m, 10m });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName", "GovernorateId", "NormalCostShipping", "PickUpCostShipping" },
                values: new object[] { 2, "الاميرية", 2, 10m, 10m });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "BranchId", "CityId", "CompanyValue", "CustomerName", "Email", "FirstPhone", "GovernorateId", "IsVillage", "MerchantAddress", "MerchantPhone", "Notes", "OrderCost", "OrderDate", "OrderStatusId", "OrderTypeId", "PaidShippingValue", "PaymentTypeId", "RecievedAmount", "SecondPhone", "ShippingCost", "ShippingTypeId", "StreetAndVillage", "TotalWeight" },
                values: new object[,]
                {
                    { 1, 1, 1, 0f, "mahmoud", "m@me.com", "010106171222", 1, false, "address", "12321312", null, 0f, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(7975), 1, 1, 0f, 1, 0f, null, 0f, 1, "menouf", 0f },
                    { 2, 1, 1, 0f, "mahmoud", "m@me.com", "010106171222", 1, false, "address", "12321312", null, 0f, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(7990), 1, 1, 0f, 1, 0f, null, 0f, 1, "menouf", 0f },
                    { 3, 1, 1, 0f, "mahmoud", "m@me.com", "010106171222", 1, false, "address", "12321312", null, 0f, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(7998), 1, 1, 0f, 1, 0f, null, 0f, 1, "menouf", 0f },
                    { 4, 1, 1, 0f, "mahmoud", "m@me.com", "010106171222", 1, false, "address", "12321312", null, 0f, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(8005), 1, 1, 0f, 1, 0f, null, 0f, 1, "menouf", 0f },
                    { 5, 1, 1, 0f, "mahmoud", "m@me.com", "010106171222", 1, false, "address", "12321312", null, 0f, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(8011), 1, 1, 0f, 1, 0f, null, 0f, 1, "menouf", 0f },
                    { 6, 1, 1, 0f, "mahmoud", "m@me.com", "010106171222", 1, false, "address", "12321312", null, 0f, new DateTime(2022, 10, 14, 11, 37, 40, 803, DateTimeKind.Local).AddTicks(8018), 1, 1, 0f, 1, 0f, null, 0f, 1, "menouf", 0f }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "OrderId", "ProductName", "ProductWeight", "Quantity" },
                values: new object[] { 1, 1, "new product", 20.5f, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_GovernorateId",
                table: "City",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BranchId",
                table: "Order",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CityId",
                table: "Order",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_GovernorateId",
                table: "Order",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingTypeId",
                table: "Order",
                column: "ShippingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "WeightSetting");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "ShippingType");

            migrationBuilder.DropTable(
                name: "Governorate");
        }
    }
}
