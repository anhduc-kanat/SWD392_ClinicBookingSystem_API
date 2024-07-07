using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class adddentistintomeetings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "AppointmentBusinessServices");

            migrationBuilder.DropColumn(
                name: "DentistName",
                table: "AppointmentBusinessServices");

            migrationBuilder.AddColumn<int>(
                name: "DentistId",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DentistName",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "DentistName",
                table: "Meetings");

            migrationBuilder.AddColumn<int>(
                name: "DentistId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DentistName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
