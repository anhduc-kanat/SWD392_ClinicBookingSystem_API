using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class FixNameInAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServicesId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Slots_SlotsId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "SlotsId",
                table: "Appointments",
                newName: "SlotId");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "Appointments",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_SlotsId",
                table: "Appointments",
                newName: "IX_Appointments_SlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServicesId",
                table: "Appointments",
                newName: "IX_Appointments_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Slots_SlotId",
                table: "Appointments",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Slots_SlotId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "SlotId",
                table: "Appointments",
                newName: "SlotsId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Appointments",
                newName: "ServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_SlotId",
                table: "Appointments",
                newName: "IX_Appointments_SlotsId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                newName: "IX_Appointments_ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServicesId",
                table: "Appointments",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Slots_SlotsId",
                table: "Appointments",
                column: "SlotsId",
                principalTable: "Slots",
                principalColumn: "Id");
        }
    }
}
