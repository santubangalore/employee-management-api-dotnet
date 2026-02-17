using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class onboardingmodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerificationDone",
                table: "Onboarding",
                newName: "VerificationStage");

            migrationBuilder.RenameColumn(
                name: "Documents",
                table: "Onboarding",
                newName: "UploadedDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "OnBoardingCompleted",
                table: "Onboarding",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnBoardingCompleted",
                table: "Onboarding");

            migrationBuilder.RenameColumn(
                name: "VerificationStage",
                table: "Onboarding",
                newName: "VerificationDone");

            migrationBuilder.RenameColumn(
                name: "UploadedDocuments",
                table: "Onboarding",
                newName: "Documents");
        }
    }
}
