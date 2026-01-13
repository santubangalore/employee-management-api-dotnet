using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class salaryallowancedeductionstructplusconverter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaXRebateCodes_TaxDeductions_TaxDeductionsId",
                table: "TaXRebateCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxSlabs_TaxDeductions_TaxDeductionsId",
                table: "TaxSlabs");

            migrationBuilder.DropIndex(
                name: "IX_TaxSlabs_TaxDeductionsId",
                table: "TaxSlabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaXRebateCodes",
                table: "TaXRebateCodes");

            migrationBuilder.DropIndex(
                name: "IX_TaXRebateCodes_TaxDeductionsId",
                table: "TaXRebateCodes");

            migrationBuilder.DropColumn(
                name: "TaxDeductionsId",
                table: "TaxSlabs");

            migrationBuilder.DropColumn(
                name: "TaxDeductionsId",
                table: "TaXRebateCodes");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Onboarding");

            migrationBuilder.RenameTable(
                name: "TaXRebateCodes",
                newName: "TaxRebateCodes");

            migrationBuilder.RenameColumn(
                name: "TaxValue",
                table: "TaxDeductions",
                newName: "TotTaxAmount");

            migrationBuilder.AlterColumn<string>(
                name: "RebateCode",
                table: "TaxRebateCodes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RebateDesc",
                table: "TaxRebateCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotRebateAmount",
                table: "TaxDeductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FinYear",
                table: "EmployeeSalary",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxRebateCodes",
                table: "TaxRebateCodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeCertificateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnboardingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_Onboarding_OnboardingId",
                        column: x => x.OnboardingId,
                        principalTable: "Onboarding",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTaxRebate",
                columns: table => new
                {
                    EmployeeTaxRebateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RebateId = table.Column<int>(type: "int", nullable: false),
                    TaxRebateId = table.Column<int>(type: "int", nullable: false),
                    DocumentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinYear = table.Column<int>(type: "int", nullable: false),
                    EmployeeRebateAmount = table.Column<int>(type: "int", nullable: false),
                    TaxDeductionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaxRebate", x => x.EmployeeTaxRebateId);
                    table.ForeignKey(
                        name: "FK_EmployeeTaxRebate_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTaxRebate_TaxDeductions_TaxDeductionsId",
                        column: x => x.TaxDeductionsId,
                        principalTable: "TaxDeductions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeTaxRebate_TaxRebateCodes_TaxRebateId",
                        column: x => x.TaxRebateId,
                        principalTable: "TaxRebateCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnboardingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperience_Onboarding_OnboardingId",
                        column: x => x.OnboardingId,
                        principalTable: "Onboarding",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_OnboardingId",
                table: "Education",
                column: "OnboardingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaxRebate_EmployeeId",
                table: "EmployeeTaxRebate",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaxRebate_TaxDeductionsId",
                table: "EmployeeTaxRebate",
                column: "TaxDeductionsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaxRebate_TaxRebateId",
                table: "EmployeeTaxRebate",
                column: "TaxRebateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_OnboardingId",
                table: "WorkExperience",
                column: "OnboardingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "EmployeeTaxRebate");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxRebateCodes",
                table: "TaxRebateCodes");

            migrationBuilder.DropColumn(
                name: "RebateDesc",
                table: "TaxRebateCodes");

            migrationBuilder.DropColumn(
                name: "TotRebateAmount",
                table: "TaxDeductions");

            migrationBuilder.DropColumn(
                name: "FinYear",
                table: "EmployeeSalary");

            migrationBuilder.RenameTable(
                name: "TaxRebateCodes",
                newName: "TaXRebateCodes");

            migrationBuilder.RenameColumn(
                name: "TotTaxAmount",
                table: "TaxDeductions",
                newName: "TaxValue");

            migrationBuilder.AddColumn<int>(
                name: "TaxDeductionsId",
                table: "TaxSlabs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RebateCode",
                table: "TaXRebateCodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "TaxDeductionsId",
                table: "TaXRebateCodes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Onboarding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaXRebateCodes",
                table: "TaXRebateCodes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaxSlabs_TaxDeductionsId",
                table: "TaxSlabs",
                column: "TaxDeductionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TaXRebateCodes_TaxDeductionsId",
                table: "TaXRebateCodes",
                column: "TaxDeductionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaXRebateCodes_TaxDeductions_TaxDeductionsId",
                table: "TaXRebateCodes",
                column: "TaxDeductionsId",
                principalTable: "TaxDeductions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxSlabs_TaxDeductions_TaxDeductionsId",
                table: "TaxSlabs",
                column: "TaxDeductionsId",
                principalTable: "TaxDeductions",
                principalColumn: "Id");
        }
    }
}
