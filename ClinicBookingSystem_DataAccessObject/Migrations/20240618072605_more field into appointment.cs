using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class morefieldintoappointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserTreatmentId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserBookingId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DentistBookingId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DentistBookingName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffBookingId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffBookingName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DentistBookingId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DentistBookingName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StaffBookingId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StaffBookingName",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "UserTreatmentId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserBookingId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
