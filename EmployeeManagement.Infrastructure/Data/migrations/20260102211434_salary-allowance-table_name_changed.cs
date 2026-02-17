using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class salaryallowancetable_name_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_EmployeeSalary_EmployeeSalaryId",
                table: "Allowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allowances",
                table: "Allowances");

            migrationBuilder.RenameTable(
                name: "Allowances",
                newName: "EmployeeAllowances");

            migrationBuilder.RenameIndex(
                name: "IX_Allowances_EmployeeSalaryId",
                table: "EmployeeAllowances",
                newName: "IX_EmployeeAllowances_EmployeeSalaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAllowances",
                table: "EmployeeAllowances",
                column: "EployeeAllowancesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAllowances_EmployeeSalary_EmployeeSalaryId",
                table: "EmployeeAllowances",
                column: "EmployeeSalaryId",
                principalTable: "EmployeeSalary",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAllowances_EmployeeSalary_EmployeeSalaryId",
                table: "EmployeeAllowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAllowances",
                table: "EmployeeAllowances");

            migrationBuilder.RenameTable(
                name: "EmployeeAllowances",
                newName: "Allowances");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeAllowances_EmployeeSalaryId",
                table: "Allowances",
                newName: "IX_Allowances_EmployeeSalaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allowances",
                table: "Allowances",
                column: "EployeeAllowancesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_EmployeeSalary_EmployeeSalaryId",
                table: "Allowances",
                column: "EmployeeSalaryId",
                principalTable: "EmployeeSalary",
                principalColumn: "Id");
        }
    }
}
