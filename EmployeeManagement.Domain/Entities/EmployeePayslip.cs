using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class EmployeePayslip
    {
        public int PayslipId { get; set; }
        public int EmployeeId { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int BasicSalary { get; set; }
        public List<AllowancesTypes>  AllowancesTypes { get; set; }
        public List<Deductions> Deductions { get; set; }
        public int FinalSalary { get; set; }
    }

    public class Deductions
    {
        public int DeductionId { get; set; }
        public int EmployeeId { get; set; }
        public int PFAmount {  get; set; } 
        public string PFUAN { get; set; }
        public List<TaxDeductions> TaxDeductions { get; set; }

    }
}
