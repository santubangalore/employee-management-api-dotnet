using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class salarydeductionsstructchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_TaxDeductions_TaxDeductionsId",
                table: "EmployeeSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaxRebate_Employees_EmployeeId",
                table: "EmployeeTaxRebate");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTaxRebate_EmployeeId",
                table: "EmployeeTaxRebate");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalary");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalary_TaxDeductionsId",
                table: "EmployeeSalary");

            migrationBuilder.DropColumn(
                name: "PFDeduction",
                table: "EmployeeSalary");

            migrationBuilder.DropColumn(
                name: "ProfTax",
                table: "EmployeeSalary");

            migrationBuilder.DropColumn(
                name: "TaxDeducted",
                table: "EmployeeSalary");

            migrationBuilder.RenameColumn(
                name: "TaxDeductionsId",
                table: "EmployeeSalary",
                newName: "TotDeductions");

            migrationBuilder.AddColumn<int>(
                name: "PfDeduction",
                table: "TaxDeductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfTax",
                table: "TaxDeductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentDetails",
                table: "EmployeeTaxRebate",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DeductionsId",
                table: "EmployeeSalary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_DeductionsId",
                table: "EmployeeSalary",
                column: "DeductionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_TaxDeductions_DeductionsId",
                table: "EmployeeSalary",
                column: "DeductionsId",
                principalTable: "TaxDeductions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

         
            migrationBuilder.DropColumn(
                name: "PfDeduction",
                table: "TaxDeductions");

            migrationBuilder.DropColumn(
                name: "ProfTax",
                table: "TaxDeductions");

            migrationBuilder.DropColumn(
                name: "DeductionsId",
                table: "EmployeeSalary");

            migrationBuilder.RenameColumn(
                name: "TotDeductions",
                table: "EmployeeSalary",
                newName: "TaxDeductionsId");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentDetails",
                table: "EmployeeTaxRebate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PFDeduction",
                table: "EmployeeSalary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfTax",
                table: "EmployeeSalary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxDeducted",
                table: "EmployeeSalary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaxRebate_EmployeeId",
                table: "EmployeeTaxRebate",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_TaxDeductionsId",
                table: "EmployeeSalary",
                column: "TaxDeductionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_TaxDeductions_TaxDeductionsId",
                table: "EmployeeSalary",
                column: "TaxDeductionsId",
                principalTable: "TaxDeductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaxRebate_Employees_EmployeeId",
                table: "EmployeeTaxRebate",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
