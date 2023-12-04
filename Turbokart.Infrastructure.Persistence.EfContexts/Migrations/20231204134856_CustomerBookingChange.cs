using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turbokart.Infrastructure.Persistence.EfContexts.Migrations
{
    /// <inheritdoc />
    public partial class CustomerBookingChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
