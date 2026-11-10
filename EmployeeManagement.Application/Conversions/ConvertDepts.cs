using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertDepts (IConfiguration config,IEncryption encryption)
    {
        public static ChildDeptDTO ConvertToChildDeptDto(ChildDepartment childDept,string ParentDeptName)
        {
            if (childDept is null) return null;
            return new ChildDeptDTO()
            {
                ChildDeptId = childDept.ChildDeptId,
                DepartmentName = childDept.DepartmentName,
                ParentDepartmentName = ParentDeptName,
                ParentDeptId = childDept.ParentDeptId,
            };
        }

        public static List<ChildDeptDTO> ConvertToChildDeptsDto(IEnumerable<ChildDepartment> childDepts, IEnumerable<ParentDepartment> parentDepts)
        {
            if (childDepts.Count() <= 0) return null;
            var result = from childDept in childDepts
                         join parentDept in parentDepts
                         on childDept.ParentDeptId equals parentDept.DepartmentId
                         select new ChildDeptDTO()
                         {
                             ChildDeptId = childDept.ChildDeptId,
                             DepartmentName = childDept.DepartmentName,
                             ParentDepartmentName = parentDept.DepartmentName,
                             ParentDeptId = childDept.ParentDeptId,
                         };
            
            return result.ToList();
        }

        public static ChildDepartment ConvertToChildDepartment(ChildDeptDTO childDeptDto)
        {
            if (childDeptDto is null) return null;
            return new ChildDepartment()
            {
                ChildDeptId = childDeptDto.ChildDeptId,
                DepartmentName = childDeptDto.DepartmentName,
                ParentDeptId = childDeptDto.ParentDeptId,
            };
        }

        /// <summary>
        /// DTO's to Entity
        /// </summary>
        /// <param name="parentDeptDto"></param>
        /// <returns></returns>
        public static ParentDepartment ConvertToParentDepartment(ParentDeptDTO parentDeptDto)
        {
            if (parentDeptDto is null) return null;
            return new ParentDepartment()
            {
                DepartmentId = parentDeptDto.DepartmentId,
                DepartmentName = parentDeptDto.ParentDepartmentName,
                DepartmentLogo = parentDeptDto.DepartmentLogo
            };
        }

        /// <summary>
        /// IEnumerable<DTO> to Ienumerable<Entity>
        /// </summary>
        /// <param name="parentDepts"></param>
        /// <returns></returns>
        public static List<ParentDepartment> ConvertToParentDepartments(IEnumerable<ParentDeptDTO> parentDeptsDto)
        {
            if (parentDeptsDto.Count() <= 0) return null;
            var listParentDepts = from parentDeptdto in parentDeptsDto
                         select new ParentDepartment()
                         {
                             DepartmentId= parentDeptdto.DepartmentId,
                             DepartmentName = parentDeptdto.ParentDepartmentName,
                             DepartmentLogo = parentDeptdto.DepartmentLogo
                         };
         
            return listParentDepts.ToList();
        }

        public static ParentDeptDTO ConvertToParentDeptDto(ParentDepartment parentDept)
        {
            if (parentDept is null) return null;
            return new ParentDeptDTO()
            {
                DepartmentId  = parentDept.DepartmentId,
                ParentDepartmentName = parentDept.DepartmentName,
                DepartmentLogo = parentDept.DepartmentLogo
            };
        }

        public static List<ParentDeptDTO> ConvertToParentDeptsDto(IEnumerable<ParentDepartment> parentDepts)
        {
            if (parentDepts.Count() <= 0) return null;
            List<ParentDeptDTO> listParentDeptsDto = new List<ParentDeptDTO>();
            foreach (var dept in parentDepts)
            {
                listParentDeptsDto.Add(ConvertToParentDeptDto(dept));
            }
            return listParentDeptsDto;
        }
        
    

    }
}
