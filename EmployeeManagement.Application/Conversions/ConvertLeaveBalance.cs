using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertLeaveBalance
    {
        public static LeaveBalance ConvertToEntity(LeaveBalanceDTO leavebalance)
        {
            if (leavebalance is null) return null;
            var lrq = new LeaveBalance()
            {
                EmployeeId = leavebalance.EmployeeId,
                LeaveType = leavebalance.LeaveType,
                BalanceLeave = leavebalance.BalanceLeave,
                CreatedDate= leavebalance.CreatedDate,
                CreatedByUser =leavebalance.CreatedByUser,
                ToYear =leavebalance.ToYear
            };
            return lrq;
        }

        public static LeaveBalanceDTO ConvertToDto(LeaveBalance lrq)
        {
            if (lrq is null) return null;
            return new LeaveBalanceDTO()
            {
                Id = lrq.Id,
                EmployeeId = lrq.EmployeeId,
                LeaveType = lrq.LeaveType,
                BalanceLeave = lrq.BalanceLeave,
                CreatedDate = lrq.CreatedDate,
                CreatedByUser = lrq.CreatedByUser,
                FromYear = lrq.FromYear,
                ToYear = lrq.ToYear,
            };
        }

        public static List<LeaveBalanceDTO> ConvertToDtoList(List<LeaveBalance> leaveRequests)
        {
            if (leaveRequests.Count() <= 0) return null;
            List<LeaveBalanceDTO> leaveRequestDTOs = new List<LeaveBalanceDTO>();
            foreach (var lrq in leaveRequests)
            {
                leaveRequestDTOs.Add(ConvertToDto(lrq));
            }
            return leaveRequestDTOs;
        }
    }
}
