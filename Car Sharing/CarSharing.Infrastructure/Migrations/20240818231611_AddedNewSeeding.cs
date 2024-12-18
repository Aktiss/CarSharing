using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Descriptions", "Fueltype", "ImageURL", "Model", "OwnerId", "Seats", "Transmission", "Year" },
                values: new object[] { 3, "Ferrari", "Mooi", 2, "https://www.bloemendaalcs.nl/wp-content/uploads/2015/07/2015-Ferrari-Enzo-Luxury-Automotive.jpg", "Enzo", "2", 4, 0, 2010 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
