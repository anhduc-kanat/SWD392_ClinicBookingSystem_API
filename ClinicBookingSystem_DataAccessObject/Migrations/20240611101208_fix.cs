using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_BusinessServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessServiceOrder_Services_BusinessServicesId",
                table: "BusinessServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessServiceUser_Services_BusinessServicesId",
                table: "BusinessServiceUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "BusinessServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessServices",
                table: "BusinessServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BusinessServices_BusinessServiceId",
                table: "Appointments",
                column: "BusinessServiceId",
                principalTable: "BusinessServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessServiceOrder_BusinessServices_BusinessServicesId",
                table: "BusinessServiceOrder",
                column: "BusinessServicesId",
                principalTable: "BusinessServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessServiceUser_BusinessServices_BusinessServicesId",
                table: "BusinessServiceUser",
                column: "BusinessServicesId",
                principalTable: "BusinessServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BusinessServices_BusinessServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessServiceOrder_BusinessServices_BusinessServicesId",
                table: "BusinessServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessServiceUser_BusinessServices_BusinessServicesId",
                table: "BusinessServiceUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessServices",
                table: "BusinessServices");

            migrationBuilder.RenameTable(
                name: "BusinessServices",
                newName: "Services");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_BusinessServiceId",
                table: "Appointments",
                column: "BusinessServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessServiceOrder_Services_BusinessServicesId",
                table: "BusinessServiceOrder",
                column: "BusinessServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessServiceUser_Services_BusinessServicesId",
                table: "BusinessServiceUser",
                column: "BusinessServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
