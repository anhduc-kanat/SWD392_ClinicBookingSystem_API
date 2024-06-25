using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentBusinessService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BusinessServices_BusinessServiceId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BusinessServiceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BusinessServiceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DentistAccountId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DentistAccountName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DentistTreatmentId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DentistTreatmentName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsPeriod",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsTreatment",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ReExamNumber",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ReExamUnit",
                table: "Appointments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.CreateTable(
                name: "AppointmentBusinessServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAccountId = table.Column<int>(type: "int", nullable: false),
                    CustomerAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DentistId = table.Column<int>(type: "int", nullable: false),
                    DentistName = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<long>(type: "bigint", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    BusinessServiceId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentBusinessServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentBusinessServices_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentBusinessServices_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentBusinessServices_AppointmentId",
                table: "AppointmentBusinessServices",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentBusinessServices_BusinessServiceId",
                table: "AppointmentBusinessServices",
                column: "BusinessServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentBusinessServices");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Appointments",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "BusinessServiceId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DentistAccountId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DentistAccountName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DentistTreatmentId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DentistTreatmentName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPeriod",
                table: "Appointments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTreatment",
                table: "Appointments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReExamNumber",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReExamUnit",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BusinessServiceId",
                table: "Appointments",
                column: "BusinessServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BusinessServices_BusinessServiceId",
                table: "Appointments",
                column: "BusinessServiceId",
                principalTable: "BusinessServices",
                principalColumn: "Id");
        }
    }
}
