using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class addtransactionstatusintoabs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionStatus",
                table: "AppointmentBusinessServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "AppointmentBusinessServices");
        }
    }
}
