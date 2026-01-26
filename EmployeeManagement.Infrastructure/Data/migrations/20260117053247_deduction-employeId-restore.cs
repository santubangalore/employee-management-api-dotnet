using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class deductionemployeIdrestore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.DropIndex(
                name: "IX_TaxDeductions_EmployeeSalaryId",
                table: "TaxDeductions");

            migrationBuilder.RenameColumn(
                name: "EmployeeSalaryId",
                table: "TaxDeductions",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "DeductionsId",
                table: "EmployeeSalary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_DeductionsId",
                table: "EmployeeSalary",
                column: "DeductionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_TaxDeductions_DeductionsId",
                table: "EmployeeSalary",
                column: "DeductionsId",
                principalTable: "TaxDeductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_TaxDeductions_DeductionsId",
                table: "EmployeeSalary");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalary_DeductionsId",
                table: "EmployeeSalary");

            migrationBuilder.DropColumn(
                name: "DeductionsId",
                table: "EmployeeSalary");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "TaxDeductions",
                newName: "EmployeeSalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxDeductions_EmployeeSalaryId",
                table: "TaxDeductions",
                column: "EmployeeSalaryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxDeductions_EmployeeSalary_EmployeeSalaryId",
                table: "TaxDeductions",
                column: "EmployeeId",
                principalTable: "EmployeeSalary",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
