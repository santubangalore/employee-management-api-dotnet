using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class employeesalaryrevertIdcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

    

            migrationBuilder.AddForeignKey(
                name: "FK_TaxDeductions_EmployeeSalary_EmployeeSalaryId_IX",
                table: "TaxDeductions",
                column: "EmployeeSalaryId",
                principalTable: "EmployeeSalary",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
    
        }
    }
}
