using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationShipBetweenSlotAndAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSlot");

            migrationBuilder.AddColumn<int>(
                name: "SlotsId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SlotsId",
                table: "Appointments",
                column: "SlotsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Slots_SlotsId",
                table: "Appointments",
                column: "SlotsId",
                principalTable: "Slots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Slots_SlotsId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SlotsId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SlotsId",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "AppointmentSlot",
                columns: table => new
                {
                    AppointmentsId = table.Column<int>(type: "int", nullable: false),
                    SlotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSlot", x => new { x.AppointmentsId, x.SlotsId });
                    table.ForeignKey(
                        name: "FK_AppointmentSlot_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentSlot_Slots_SlotsId",
                        column: x => x.SlotsId,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSlot_SlotsId",
                table: "AppointmentSlot",
                column: "SlotsId");
        }
    }
}
