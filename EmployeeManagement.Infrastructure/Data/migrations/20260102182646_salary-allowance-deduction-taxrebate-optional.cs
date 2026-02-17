using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class salaryallowancedeductiontaxrebateoptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaxRebate_TaxRebateCodes_TaxRebateId",
                table: "EmployeeTaxRebate");

            migrationBuilder.AlterColumn<int>(
                name: "TaxRebateId",
                table: "EmployeeTaxRebate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RebateId",
                table: "EmployeeTaxRebate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaxRebate_TaxRebateCodes_TaxRebateId",
                table: "EmployeeTaxRebate",
                column: "TaxRebateId",
                principalTable: "TaxRebateCodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaxRebate_TaxRebateCodes_TaxRebateId",
                table: "EmployeeTaxRebate");

            migrationBuilder.AlterColumn<int>(
                name: "TaxRebateId",
                table: "EmployeeTaxRebate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RebateId",
                table: "EmployeeTaxRebate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaxRebate_TaxRebateCodes_TaxRebateId",
                table: "EmployeeTaxRebate",
                column: "TaxRebateId",
                principalTable: "TaxRebateCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
