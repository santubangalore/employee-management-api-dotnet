using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class OnboardingNTimsheetAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onboardings_Employees_EmployeeId",
                table: "Onboardings");

            migrationBuilder.DropTable(
                name: "LeaveApprovalSteps");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Onboardings",
                table: "Onboardings");

            migrationBuilder.RenameTable(
                name: "Onboardings",
                newName: "Onboarding");

            migrationBuilder.RenameIndex(
                name: "IX_Onboardings_EmployeeId",
                table: "Onboarding",
                newName: "IX_Onboarding_EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Onboarding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Onboarding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Onboarding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Onboarding",
                table: "Onboarding",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TimeSheetDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimesheetSummaryId = table.Column<int>(type: "int", nullable: false),
                    WeekNo = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetDetails_TimeSheetsSummary_TimesheetSummaryId",
                        column: x => x.TimesheetSummaryId,
                        principalTable: "TimeSheetsSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetDetails_TimesheetSummaryId",
                table: "TimeSheetDetails",
                column: "TimesheetSummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Onboarding_Employees_EmployeeId",
                table: "Onboarding",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onboarding_Employees_EmployeeId",
                table: "Onboarding");

            migrationBuilder.DropTable(
                name: "TimeSheetDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Onboarding",
                table: "Onboarding");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Onboarding");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Onboarding");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Onboarding");

            migrationBuilder.RenameTable(
                name: "Onboarding",
                newName: "Onboardings");

            migrationBuilder.RenameIndex(
                name: "IX_Onboarding_EmployeeId",
                table: "Onboardings",
                newName: "IX_Onboardings_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Onboardings",
                table: "Onboardings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LeaveApprovalSteps",
                columns: table => new
                {
                    ApprovalStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalStepName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApprovalSteps", x => x.ApprovalStepId);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimesheetSummaryId = table.Column<int>(type: "int", nullable: false),
                    AttStatus = table.Column<int>(type: "int", nullable: false),
                    WeekNo = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheets_TimeSheetsSummary_TimesheetSummaryId",
                        column: x => x.TimesheetSummaryId,
                        principalTable: "TimeSheetsSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_TimesheetSummaryId",
                table: "TimeSheets",
                column: "TimesheetSummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Onboardings_Employees_EmployeeId",
                table: "Onboardings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
