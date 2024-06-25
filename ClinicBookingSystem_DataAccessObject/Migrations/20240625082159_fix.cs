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
            migrationBuilder.AddColumn<bool>(
                name: "IsReExam",
                table: "Appointments",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReExam",
                table: "Appointments");
        }
    }
}
