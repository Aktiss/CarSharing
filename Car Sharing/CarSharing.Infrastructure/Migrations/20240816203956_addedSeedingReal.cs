using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarSharing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedSeedingReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Descriptions", "Fueltype", "ImageURL", "Model", "OwnerId", "Seats", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, "Audi", "Goeie staat", 0, "https://mediaservice.audi.com/media/fast/H4sIAAAAAAAAAFvzloG1tIiBOTrayfuvpGh6-m1zJgaGigIGBgZGoDhTtNOaz-I_2DhCHsCEtzEwF-SlMwJZKUycmbmJ6an6QD4_I3taTmV-aUkxO0grT9Pa4LcrgmzOW3se3ft8EstCCWHRLQysQF2Ml4AEiwiQ4IsCEhzhDGASZN5CEHESxGcyZ2ZgYK0AMiIZQICPr7QopyCxKDFXrzwzpSRDUMOASCDM7uIa4ujpEwwAdTReUOkAAAA?wid=550", "A3", 1, 5, 0, 2020 },
                    { 2, "Citroën", "Goede staat", 1, "https://www.citroen.be/content/dam/citroen/master/no-config/noconfig-eberlingo/ice/m/xtr/kiamablue_Berlingo_M.png?imwidth=768", "Berlingo", 1, 5, 1, 2014 }
                });

            migrationBuilder.InsertData(
                table: "Borrowings",
                columns: new[] { "Id", "BorrowerId", "CarId", "EndDateTime", "Message", "StartDateTime", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Borrowing the Audi for a day trip.", new DateTime(2024, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 2, new DateTime(2024, 8, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), "Need the Citroën for moving some items.", new DateTime(2024, 8, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 0 }
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
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
