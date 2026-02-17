using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertRole
    {
        public static Role ConvertToEntity(RoleDTO prjRoleDto)
        {
            if (prjRoleDto is null) return null;
            var role = new Role()
            {
                RoleId = prjRoleDto.RoleId,
                RoleName = prjRoleDto.RoleName,
                RoleDescription = prjRoleDto.RoleDescription,
            };
            return role;
        }

        public static RoleDTO ConvertToDto(Role projectRole)
        {
            if (projectRole is null) return null;
            var role = new RoleDTO()
            {
                RoleId = projectRole.RoleId,
                RoleName = projectRole.RoleName,
                RoleDescription = projectRole.RoleDescription,
            };
            return role;
        }

        public static List<RoleDTO> ConvertToDtos(IEnumerable<Role> projectRoles)
        {
            if (projectRoles.Count() <= 0) return null;
            List<RoleDTO> projectRoleDtos = new List<RoleDTO>();
            foreach (var prjRole in projectRoles)
            {
                projectRoleDtos.Add(ConvertToDto(prjRole));
            }
            return projectRoleDtos;
        }
    }
}
