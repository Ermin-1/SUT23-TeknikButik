using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SUT23_TeknikButik.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Adress", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Horseshoeroad 2", "Ermin.husic@hotmail.com", "Ermin", "Husic", "07777777777" },
                    { 2, "Blacksheeproad 44", "oskar.johansson@hotmail.com", "Oskar", "Johansson", "077333333" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 0, 8500.00m, "Iphone 13" },
                    { 2, 0, 10000.00m, "Samsung 14" },
                    { 3, 1, 20000.00m, "Asus Rog" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderPlaced" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
