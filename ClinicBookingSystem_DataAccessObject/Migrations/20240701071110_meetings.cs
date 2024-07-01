using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class meetings : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "IsClinicalExamPaid",
                table: "Appointments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFullyPaid",
                table: "Appointments",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserTreatmentName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserTreatmentId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserAccountName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DentistName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DentistId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddColumn<int>(
                name: "MeetingCount",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalMeetingDate",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeetingAttempt = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    AppointmentBusinessServiceId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_AppointmentBusinessServices_AppointmentBusinessServiceId",
                        column: x => x.AppointmentBusinessServiceId,
                        principalTable: "AppointmentBusinessServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_AppointmentBusinessServiceId",
                table: "Meetings",
                column: "AppointmentBusinessServiceId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentBusinessServices_Appointments_AppointmentId",
                table: "AppointmentBusinessServices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentBusinessServices_BusinessServices_BusinessServiceId",
                table: "AppointmentBusinessServices");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropColumn(
                name: "IsClinicalExamPaid",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsFullyPaid",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "MeetingCount",
                table: "AppointmentBusinessServices");

            migrationBuilder.DropColumn(
                name: "TotalMeetingDate",
                table: "AppointmentBusinessServices");

            migrationBuilder.AlterColumn<string>(
                name: "UserTreatmentName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserTreatmentId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserAccountName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DentistName",
                table: "AppointmentBusinessServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DentistId",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
