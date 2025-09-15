using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertLeaveType
    {
        public static LeaveTypes ConvertToEntity(LeaveTypesDTO LeaveTypesDto)
        {
            if (LeaveTypesDto is null) return null;
            var ltdto = new LeaveTypes()
            {
                LeaveTypeId = LeaveTypesDto.LeaveTypeId,
                LeaveTypeName = LeaveTypesDto.LeaveTypeName,
            };
            return ltdto;
        }

        public static LeaveTypesDTO ConvertToDto(LeaveTypes lt)
        {
            if (lt is null) return null;
            return new LeaveTypesDTO()
            {
                LeaveTypeId = lt.LeaveTypeId,
                LeaveTypeName = lt.LeaveTypeName,
            };
        }

        public static List<LeaveTypesDTO> ConvertToDtoList(IEnumerable<LeaveTypes> lts)
        {
            if (lts.Count() <= 0) return null;
            List<LeaveTypesDTO> ltdDTOs = new List<LeaveTypesDTO>();
            foreach (var lrq in lts)
            {
                ltdDTOs.Add(ConvertToDto(lrq));
            }
            return ltdDTOs;
        }
    }
}
