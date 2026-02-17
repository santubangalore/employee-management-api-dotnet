using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class salarystructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllowancesTypes",
                columns: table => new
                {
                    AllowanceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowanceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowanceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowanceType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowancesTypes", x => x.AllowanceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaxDeductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FinYear = table.Column<int>(type: "int", nullable: false),
                    TaxValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxDeductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BasicSalary = table.Column<int>(type: "int", nullable: false),
                    ProfTax = table.Column<int>(type: "int", nullable: false),
                    PFAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PFDeduction = table.Column<int>(type: "int", nullable: false),
                    TaxDeducted = table.Column<int>(type: "int", nullable: false),
                    TaxDeductionsId = table.Column<int>(type: "int", nullable: false),
                    TakeHomeSalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_TaxDeductions_TaxDeductionsId",
                        column: x => x.TaxDeductionsId,
                        principalTable: "TaxDeductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaXRebateCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinYear = table.Column<int>(type: "int", nullable: false),
                    RebateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RebateAmount = table.Column<int>(type: "int", nullable: false),
                    TaxDeductionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaXRebateCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaXRebateCodes_TaxDeductions_TaxDeductionsId",
                        column: x => x.TaxDeductionsId,
                        principalTable: "TaxDeductions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaxSlabs",
                columns: table => new
                {
                    TaxSlabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxSlabAmount = table.Column<int>(type: "int", nullable: false),
                    TaxYear = table.Column<int>(type: "int", nullable: false),
                    TaxPercent = table.Column<float>(type: "real", nullable: false),
                    TaxDeductionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSlabs", x => x.TaxSlabId);
                    table.ForeignKey(
                        name: "FK_TaxSlabs_TaxDeductions_TaxDeductionsId",
                        column: x => x.TaxDeductionsId,
                        principalTable: "TaxDeductions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Allowances",
                columns: table => new
                {
                    EployeeAllowancesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FinYear = table.Column<int>(type: "int", nullable: false),
                    AllowanceTypeId = table.Column<int>(type: "int", nullable: false),
                    AllowanceAmount = table.Column<int>(type: "int", nullable: false),
                    EmployeeSalaryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowances", x => x.EployeeAllowancesId);
                    table.ForeignKey(
                        name: "FK_Allowances_EmployeeSalary_EmployeeSalaryId",
                        column: x => x.EmployeeSalaryId,
                        principalTable: "EmployeeSalary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowances_EmployeeSalaryId",
                table: "Allowances",
                column: "EmployeeSalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_TaxDeductionsId",
                table: "EmployeeSalary",
                column: "TaxDeductionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TaXRebateCodes_TaxDeductionsId",
                table: "TaXRebateCodes",
                column: "TaxDeductionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxSlabs_TaxDeductionsId",
                table: "TaxSlabs",
                column: "TaxDeductionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowances");

            migrationBuilder.DropTable(
                name: "AllowancesTypes");

            migrationBuilder.DropTable(
                name: "TaXRebateCodes");

            migrationBuilder.DropTable(
                name: "TaxSlabs");

            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropTable(
                name: "TaxDeductions");
        }
    }
}
