using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Infrastructure.Repositories
{
    public class HrmsRolesRepository (EmployeeMgmtContext dbContext) : IHrmsRoles
    {
        public async Task< bool> CreateHrmsRole(HrmsRoles RoleName)
        {
            var exists = await dbContext.HrmsRoles.FirstOrDefaultAsync(r => r.RoleName == RoleName.RoleName);
            if (exists != null)
            {
                return false;
            }
            await dbContext.HrmsRoles.AddAsync(RoleName);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<string>> GetHrmsRoles()
        {
            var roles = await dbContext.HrmsRoles.AsNoTracking().ToListAsync();
            List<string> roleNames = new List<string>();

            if(roles.Count > 0)
            {
                roleNames = roles.Select(r => r.RoleName).ToList();
            }
            return roleNames;
        }
    }
}
