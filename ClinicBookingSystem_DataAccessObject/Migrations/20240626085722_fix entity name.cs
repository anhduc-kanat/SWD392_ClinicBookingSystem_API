using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class fixentityname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentBusinessServices_Appointments_AppointmentId",
                table: "AppointmentBusinessServices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentBusinessServices_BusinessServices_BusinessServiceId",
                table: "AppointmentBusinessServices");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "AppointmentBusinessServices",
                newName: "UserTreatmentName");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "AppointmentBusinessServices",
                newName: "UserTreatmentId");

            migrationBuilder.RenameColumn(
                name: "CustomerAccountName",
                table: "AppointmentBusinessServices",
                newName: "UserAccountName");

            migrationBuilder.RenameColumn(
                name: "CustomerAccountId",
                table: "AppointmentBusinessServices",
                newName: "UserAccountId");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessServiceId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentBusinessServices_Appointments_AppointmentId",
                table: "AppointmentBusinessServices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentBusinessServices_BusinessServices_BusinessServiceId",
                table: "AppointmentBusinessServices",
                column: "BusinessServiceId",
                principalTable: "BusinessServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentBusinessServices_Appointments_AppointmentId",
                table: "AppointmentBusinessServices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentBusinessServices_BusinessServices_BusinessServiceId",
                table: "AppointmentBusinessServices");

            migrationBuilder.RenameColumn(
                name: "UserTreatmentName",
                table: "AppointmentBusinessServices",
                newName: "PatientName");

            migrationBuilder.RenameColumn(
                name: "UserTreatmentId",
                table: "AppointmentBusinessServices",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "UserAccountName",
                table: "AppointmentBusinessServices",
                newName: "CustomerAccountName");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "AppointmentBusinessServices",
                newName: "CustomerAccountId");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessServiceId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentBusinessServices_Appointments_AppointmentId",
                table: "AppointmentBusinessServices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentBusinessServices_BusinessServices_BusinessServiceId",
                table: "AppointmentBusinessServices",
                column: "BusinessServiceId",
                principalTable: "BusinessServices",
                principalColumn: "Id");
        }
    }
}
