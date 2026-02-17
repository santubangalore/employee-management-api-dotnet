using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertEmployeeSalary
    {
        #region EntityToDto
        public static List<EmployeeSalaryDto> ConvertSalaryEntityListToDto(IEnumerable<EmployeeSalary> employeeSalaryList, IEnumerable<Employee> employees)
        {
            if (employeeSalaryList == null) return null;
            var employeeSalaryListDto = from employeeSal in employeeSalaryList join employee in employees
                                        on employeeSal.EmployeeId equals employee.EmployeeId
                                        select
                                        new  EmployeeSalaryDto
            {
                Id = employeeSal.Id,
                BasicSalary = employeeSal.BasicSalary,
                EmployeeId = employeeSal.EmployeeId,
                EmployeeName=employee.EmployeeName,
                PFAccount = employeeSal.PFAccount,
                FinYear = employeeSal.FinYear,
                Allowances = ConvertAllowanceEntityToDto(employeeSal.Allowences),
                Deductions = ConvertTaxDeductionsToDto(employeeSal.Deductions),
                TotDeductions = employeeSal.TotDeductions,
                TakeHomeSalary = employeeSal.TakeHomeSalary,
            };
            return employeeSalaryListDto.ToList();
        }

        public static EmployeeSalaryDto ConvertSalaryEntityToDto(EmployeeSalary employeeSalary)
        {
            if (employeeSalary == null) return null;
            var employeeSalaryDto =  new EmployeeSalaryDto
                                    {
                                        Id = employeeSalary.Id,
                                        BasicSalary  = employeeSalary.BasicSalary,
                                        EmployeeId = employeeSalary.EmployeeId,
                                        PFAccount = employeeSalary.PFAccount,
                                        FinYear = employeeSalary.FinYear,
                                        Allowances= ConvertAllowanceEntityToDto(employeeSalary.Allowences),
                                        Deductions = ConvertTaxDeductionsToDto(employeeSalary.Deductions),
                                        TotDeductions = employeeSalary.TotDeductions,
                                        TakeHomeSalary=employeeSalary.TakeHomeSalary,
                                    };
            return employeeSalaryDto;
        }

        private static TaxDeductionsDto ConvertTaxDeductionsToDto(TaxDeductions taxDeductions)
        {
            if (taxDeductions == null) return null;
            var taxDeuctionsDto = new TaxDeductionsDto
            {
                EmployeeId = taxDeductions.EmployeeId,
                FinYear = taxDeductions.FinYear,
                ProfTax = taxDeductions.ProfTax,
                PfDeduction = taxDeductions.PfDeduction,
                TotTaxAmount = taxDeductions.TotTaxAmount,
                InsuranceAmt = taxDeductions.InsuranceAmt,
                TotRebateAmount = taxDeductions.TotRebateAmount,
                TaxRebates = taxDeductions.TaxRebate is null ? null: ConvertTaxRebateDto(taxDeductions.TaxRebate)
            };
            return taxDeuctionsDto;
        }

        private static List<EmployeeTaxRebateDto> ConvertTaxRebateDto(List<EmployeeTaxRebate> taxRebates)
        {
            var taxRebateDto = from taxRebate in taxRebates
                              select new EmployeeTaxRebateDto
                              {
                                  EmployeeTaxRebateId = taxRebate.EmployeeTaxRebateId,
                                  EmployeeRebateAmount = taxRebate.EmployeeRebateAmount,
                                  EmployeeId = taxRebate.EmployeeId,
                                  FinYear = taxRebate.FinYear
                              };
            return taxRebateDto.ToList();
        }

        public static List<EmployeeAllowancesDto> ConvertAllowanceEntityToDto(List<EmployeeAllowances> employeeAllowances)
        {
            if (employeeAllowances == null) return null;
            var employeeAllowance = from empAllowance in employeeAllowances
                                    select new EmployeeAllowancesDto
                                    {
                                        AllowanceAmount = empAllowance.AllowanceAmount,
                                        AllowanceTypeId = empAllowance.AllowanceTypeId,
                                        EmployeeId = empAllowance.EmployeeId,
                                        EployeeAllowancesId = empAllowance.EployeeAllowancesId,
                                        FinYear = empAllowance.FinYear,
                                    };

            return employeeAllowance.ToList();
        }

        #endregion

        #region DtoToEntity
        //Dto's to Entity
        public static EmployeeSalary ConvertSalaryDtoToEntity(EmployeeSalaryDto employeeSalaryDto)
        {
            if (employeeSalaryDto == null) return null;
            if (employeeSalaryDto.PFAccount == "string" | employeeSalaryDto.PFAccount.Trim()=="") return null;
            var employeeSalary = new EmployeeSalary
            {
                Id = employeeSalaryDto.Id,
                BasicSalary = employeeSalaryDto.BasicSalary,
                EmployeeId = employeeSalaryDto.EmployeeId,
                PFAccount = employeeSalaryDto.PFAccount,
                FinYear = employeeSalaryDto.FinYear,
                TotDeductions = employeeSalaryDto.TotDeductions,
                Allowences = ConvertAllowanceDtoToEntityList(employeeSalaryDto.Allowances),
                Deductions = ConvertTaxDeductionsDtoToEntity(employeeSalaryDto.Deductions),
                TakeHomeSalary = employeeSalaryDto.TakeHomeSalary,
            };
            return employeeSalary;
        }

        public static TaxDeductions ConvertTaxDeductionsDtoToEntity(TaxDeductionsDto taxDeductionsDto)
        {
            var taxDeuctions = new TaxDeductions
            {
                EmployeeId = taxDeductionsDto.EmployeeId,
                FinYear = taxDeductionsDto.FinYear,
                ProfTax = taxDeductionsDto.ProfTax,
                PfDeduction = taxDeductionsDto.PfDeduction,
                TotTaxAmount = taxDeductionsDto.TotTaxAmount,
                InsuranceAmt = taxDeductionsDto.InsuranceAmt,
                TotRebateAmount = taxDeductionsDto.TotRebateAmount,
                TaxRebate = ConvertTaxRebateToEntity(taxDeductionsDto.TaxRebates)
            };
            return taxDeuctions;
        }

        private static List<EmployeeTaxRebate> ConvertTaxRebateToEntity(List<EmployeeTaxRebateDto> taxRebates)
        {
            var taxRebate = from tax in taxRebates
                               select new EmployeeTaxRebate
                               {
                                   EmployeeTaxRebateId = tax.EmployeeTaxRebateId,
                                   EmployeeId = tax.EmployeeId,
                                   EmployeeRebateAmount = tax.EmployeeRebateAmount,
                                   RebateId = tax.RebateId,
                                   DocumentDetails=tax.DocumentDetails,
                                   FinYear = tax.FinYear,
                               };
            return taxRebate.ToList();
        }

        public static List<EmployeeAllowances> ConvertAllowanceDtoToEntityList(List<EmployeeAllowancesDto> employeeAllowances)
        {
            if (employeeAllowances == null) return null;
            var employeeAllowance = from empAllowance in employeeAllowances
                                    select new EmployeeAllowances
                                    {
                                        AllowanceAmount = empAllowance.AllowanceAmount,
                                        AllowanceTypeId = empAllowance.AllowanceTypeId,
                                        EmployeeId = empAllowance.EmployeeId,
                                        EployeeAllowancesId = empAllowance.EployeeAllowancesId,
                                        FinYear = empAllowance.FinYear,

                                    };

            return employeeAllowance.ToList();
        }

        public static EmployeeAllowances ConvertAllowanceDtoToEntity(EmployeeAllowancesDto employeeAllowance)
        {
            if (employeeAllowance == null) return null;
            var employeeAllowanceEntity = new EmployeeAllowances
                                    {
                                        AllowanceAmount = employeeAllowance.AllowanceAmount,
                                        AllowanceTypeId = employeeAllowance.AllowanceTypeId,
                                        EmployeeId = employeeAllowance.EmployeeId,
                                        EployeeAllowancesId = employeeAllowance.EployeeAllowancesId,
                                        FinYear = employeeAllowance.FinYear,
                                    };

            return employeeAllowanceEntity;
        }
        #endregion
    }
}
