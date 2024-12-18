using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_API_CarSharing.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Borrowings",
                columns: new[] { "Id", "BorrowerId", "CarId", "EndDateTime", "Message", "StartDateTime", "Status" },
                values: new object[,]
                {
                    { 1, "borrower1", 1, new DateTime(2024, 8, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", new DateTime(2024, 8, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "borrower2", 2, new DateTime(2024, 8, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "borrower3", 3, new DateTime(2024, 8, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "Change of plans, need to cancel.", new DateTime(2024, 8, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Description", "Fueltype", "ImageURL", "Model", "OwnerId", "Seats", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, "Tesla", "A luxury electric sedan.", 2, "https://example.com/tesla-model-s.jpg", "Model S", "owner1", 5, 0, 2020 },
                    { 2, "Toyota", "A reliable compact car.", 0, "https://example.com/toyota-corolla.jpg", "Corolla", "owner2", 5, 1, 2019 },
                    { 3, "Ford", "A classic American muscle car.", 0, "https://example.com/ford-mustang.jpg", "Mustang", "owner3", 4, 0, 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
