using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeSalary :IGenericRepoInterface<EmployeeSalary>
    {
        Task<Response> CreateAllowanceAsync(List<EmployeeAllowances> allowances);
        Task<Response> UpdateAllowanceAsync(List<EmployeeAllowances> allowances);
        Task<Response> DeleteAllowancesAsync(int EmployeeId);
        Task<Response> DeleteAllowanceAsync(int EmployeeId, int AllowanceId);
        Task<List<EmployeeAllowances>> GetEmployeeAllowancesAsync(int EmployeeId);
        Task<Response> CreateTaxDeductionsAsync(TaxDeductions taxDeductions);
        Task<Response> UpdateTaxDeductionsAsync(TaxDeductions taxDeductions);
        Task<Response> DeleteTaxDeductionsAsync(int EmployeeId);
        Task<Response> AddEmployeeAllowanceAsync(EmployeeAllowances allowance);
        Task<TaxDeductions> GetEmployeeTaxDeductionsAsync(int EmployeeId);

    }
}
