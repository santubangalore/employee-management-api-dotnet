using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class HrmsRolesRepository : IHrmsRoles
    {
        public async Task< bool> CreateHrmsRole(string RoleName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetHrmsRoles()
        {
            return new List<string>
            {
                "Admin",
                "SuperAdmin",
                "DeptHead",
                "User"
            };
        }
    }
}
