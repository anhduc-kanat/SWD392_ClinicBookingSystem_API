using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class ispaidinabs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsPaid",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "AppointmentBusinessServices");
        }
    }
}
