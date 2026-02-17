using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertAllowance
    {
        public static AllowancesTypesDto ConvertAllowanceToDto(AllowancesTypes allowanceEntity)
        {
            if (allowanceEntity == null) return null;
            var allowancesTypesDto = new AllowancesTypesDto
            {
              AllowanceTypeId= allowanceEntity.AllowanceTypeId,
              AllowanceDescription= allowanceEntity.AllowanceDescription,
              AllowanceName= allowanceEntity.AllowanceName,
              AllowanceType= allowanceEntity.AllowanceType,
            };
            return allowancesTypesDto;
        }

        public static List<AllowancesTypesDto> ConvertAllowanceToDtoList(List<AllowancesTypes> allowanceEntitys)
        {
            var allowancesTypesDto = from allowanceType in allowanceEntitys
                                     select new AllowancesTypesDto
                                     {
                                      AllowanceTypeId = allowanceType.AllowanceTypeId,
                                      AllowanceDescription = allowanceType.AllowanceDescription,
                                      AllowanceName = allowanceType.AllowanceName,
                                      AllowanceType = allowanceType.AllowanceType,
                                     };
            return allowancesTypesDto.ToList();
        }

        public static AllowancesTypes ConvertAllowancesTypesToEntity(AllowancesTypesDto allowancesTypesDto)
        {
            if (allowancesTypesDto == null) return null;
            var allowancesTypes = new AllowancesTypes
            {
                AllowanceTypeId = allowancesTypesDto.AllowanceTypeId,
                AllowanceDescription = allowancesTypesDto.AllowanceDescription,
                AllowanceName = allowancesTypesDto.AllowanceName,
                AllowanceType = allowancesTypesDto.AllowanceType,

            };
            return allowancesTypes;
        }
    }
}
