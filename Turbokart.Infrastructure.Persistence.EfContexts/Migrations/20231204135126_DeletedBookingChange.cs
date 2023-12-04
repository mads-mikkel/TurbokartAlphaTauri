using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turbokart.Infrastructure.Persistence.EfContexts.Migrations
{
    /// <inheritdoc />
    public partial class DeletedBookingChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DeletedBookings");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "DeletedBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DeletedBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "DeletedBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
