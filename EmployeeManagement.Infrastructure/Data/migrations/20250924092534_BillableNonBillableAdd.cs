using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class BillableNonBillableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Onboarding");

            migrationBuilder.RenameColumn(
                name: "OnBoardingDate",
                table: "Onboarding",
                newName: "OnboardingStartDate");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "LeaveBalances",
                newName: "ToYear");

            migrationBuilder.AddColumn<int>(
                name: "BillableHours",
                table: "TimeSheetsSummary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NonBillableHours",
                table: "TimeSheetsSummary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Onboarding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Onboarding",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FromYear",
                table: "LeaveBalances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillableHours",
                table: "TimeSheetsSummary");

            migrationBuilder.DropColumn(
                name: "NonBillableHours",
                table: "TimeSheetsSummary");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Onboarding");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Onboarding");

            migrationBuilder.DropColumn(
                name: "FromYear",
                table: "LeaveBalances");

            migrationBuilder.RenameColumn(
                name: "OnboardingStartDate",
                table: "Onboarding",
                newName: "OnBoardingDate");

            migrationBuilder.RenameColumn(
                name: "ToYear",
                table: "LeaveBalances",
                newName: "Year");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Onboarding",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
