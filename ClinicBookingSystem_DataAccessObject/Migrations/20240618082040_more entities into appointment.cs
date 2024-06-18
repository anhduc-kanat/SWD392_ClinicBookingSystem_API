using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class moreentitiesintoappointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserBookingName",
                table: "Appointments",
                newName: "UserAccountName");

            migrationBuilder.RenameColumn(
                name: "UserBookingId",
                table: "Appointments",
                newName: "UserAccountId");

            migrationBuilder.RenameColumn(
                name: "StaffBookingName",
                table: "Appointments",
                newName: "StaffAccountName");

            migrationBuilder.RenameColumn(
                name: "StaffBookingId",
                table: "Appointments",
                newName: "StaffAccountId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Appointments",
                newName: "DentistTreatmentName");

            migrationBuilder.RenameColumn(
                name: "DentistBookingName",
                table: "Appointments",
                newName: "DentistAccountName");

            migrationBuilder.RenameColumn(
                name: "DentistBookingId",
                table: "Appointments",
                newName: "DentistTreatmentId");

            migrationBuilder.AddColumn<int>(
                name: "DentistAccountId",
                table: "Appointments",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DentistAccountId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserAccountName",
                table: "Appointments",
                newName: "UserBookingName");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "Appointments",
                newName: "UserBookingId");

            migrationBuilder.RenameColumn(
                name: "StaffAccountName",
                table: "Appointments",
                newName: "StaffBookingName");

            migrationBuilder.RenameColumn(
                name: "StaffAccountId",
                table: "Appointments",
                newName: "StaffBookingId");

            migrationBuilder.RenameColumn(
                name: "DentistTreatmentName",
                table: "Appointments",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "DentistTreatmentId",
                table: "Appointments",
                newName: "DentistBookingId");

            migrationBuilder.RenameColumn(
                name: "DentistAccountName",
                table: "Appointments",
                newName: "DentistBookingName");
        }
    }
}
