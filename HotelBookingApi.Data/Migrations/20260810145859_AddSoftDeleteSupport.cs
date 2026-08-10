using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Hotels");
        }
    }
}
