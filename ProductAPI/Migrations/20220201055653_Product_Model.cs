using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class Product_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "product_db");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "product_db",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "Text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc)),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "product_db",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "UpdateAt" },
                values: new object[] { new Guid("02888178-1f55-4ec5-85f3-93cfca87be48"), "Extreme Performance: Crush the competition with the impressive power and speed of the 11th Generation Intel Core i7-11800H processor, featuring 8 cores and 16 threads to divide and conquer any task or run your most intensive games", "Acer Predator Helios 300 PH315-54-760S", 1375m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "product_db",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "UpdateAt" },
                values: new object[] { new Guid("2edcbc88-3eed-45d2-a856-18c604ddb350"), "15.6-inch FHD (Full HD 1920 x 1080) 144Hz 7ms 300-nits 72% color gamut Generation Intel Core i7 - 10870H(8 - Core, 16MB Cache, up to 5.0GHz Turbo Frequency", "Alienware m15 R4 Gaming Laptop", 1745m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "product_db");
        }
    }
}
