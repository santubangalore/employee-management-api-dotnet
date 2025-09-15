using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertLeaveRequest
    {
        public static LeaveRequest ConvertToEntity(LeaveRequestDTO leaveRequest)
        {
            if (leaveRequest is null) return null;
            var lrq = new LeaveRequest()
            {
                EmployeeId = leaveRequest.EmployeeId,
                LeaveTypeId = leaveRequest.LeaveTypeId,
                LeaveStatus = leaveRequest.LeaveStatus,
                Reason = leaveRequest.Reason,
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                RequestDate = DateTime.UtcNow.ToShortDateString(),
            };
            return lrq;
        }

        public static LeaveRequestDTO ConvertToDto(LeaveRequest lrq)
        {
            if (lrq is null) return null;
            return new LeaveRequestDTO()
            {
                EmployeeId = lrq.EmployeeId,
                LeaveTypeId = lrq.LeaveTypeId,
                LeaveStatus = lrq.LeaveStatus,
                Reason = lrq.Reason,
                StartDate = lrq.StartDate,
                EndDate = lrq.EndDate,
                RequestDate = lrq.RequestDate,
            };
        }

        public static List<LeaveRequestDTO> ConvertToDtoList(List<LeaveRequest> leaveRequests)
        {
            if (leaveRequests.Count() <= 0) return null;
            List<LeaveRequestDTO> leaveRequestDTOs = new List<LeaveRequestDTO>();
            foreach (var lrq in leaveRequests)
            {
                leaveRequestDTOs.Add(ConvertToDto(lrq));
            }
            return leaveRequestDTOs;
        }
    }
}
