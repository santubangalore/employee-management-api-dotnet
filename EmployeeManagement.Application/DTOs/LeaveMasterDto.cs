using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    internal class LeaveMasterDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int EarnedLeaves { get; set; }
        public int CasualLeaves { get; set; }
        public int MedicalLeave { get; set; }
        public int CarryForward { get; set; }
    }
}
