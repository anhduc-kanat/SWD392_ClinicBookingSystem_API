using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem_DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class Createnoteaddmorefieldsintoresult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Results",
                newName: "UserTreatmentId");

            migrationBuilder.RenameColumn(
                name: "DentistId",
                table: "Results",
                newName: "UserAccountId");

            migrationBuilder.AddColumn<string>(
                name: "UserAccountName",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserTreatmentName",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DentistId = table.Column<int>(type: "int", nullable: false),
                    DentistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserProfileId",
                table: "Results",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ResultId",
                table: "Note",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_UserProfiles_UserProfileId",
                table: "Results",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_UserProfiles_UserProfileId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Results_UserProfileId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "UserAccountName",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "UserTreatmentName",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "UserTreatmentId",
                table: "Results",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "Results",
                newName: "DentistId");
        }
    }
}
