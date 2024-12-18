using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdGone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BorrowerId",
                table: "Borrowings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1,
                column: "BorrowerId",
                value: "268fd75b-5b27-455f-9f3d-a6c49db19db9");

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2,
                column: "BorrowerId",
                value: "268fd75b-5b27-455f-9f3d-a6c49db19db9");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: "268fd75b-5b27-455f-9f3d-a6c49db19db9");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerId",
                value: "268fd75b-5b27-455f-9f3d-a6c49db19db9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BorrowerId",
                table: "Borrowings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1,
                column: "BorrowerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2,
                column: "BorrowerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerId",
                value: 1);
        }
    }
}
