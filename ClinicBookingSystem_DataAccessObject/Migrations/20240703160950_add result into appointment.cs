using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class addresultintoappointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Appointments_AppointmentId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_AppointmentId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_AppointmentId",
                table: "Results",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Appointments_AppointmentId",
                table: "Results",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Appointments_AppointmentId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_AppointmentId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Results_AppointmentId",
                table: "Results",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Appointments_AppointmentId",
                table: "Results",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }
    }
}
