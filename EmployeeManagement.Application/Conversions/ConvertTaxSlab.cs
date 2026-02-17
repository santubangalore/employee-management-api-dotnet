using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertTaxSlab
    {
        public static TaxRebateDto ConvertTaxRebateEntityToDto(TaxRebate taxRebate)
        {
            if (taxRebate == null) return null;
            var taxRebateDto = new TaxRebateDto
            {
                FinYear = taxRebate.FinYear,
                Id = taxRebate.Id,
                RebateCode = taxRebate.RebateCode,
                RebateAmount = taxRebate.RebateAmount,
                RebateDesc = taxRebate.RebateDesc

            };
            return taxRebateDto;
        }
        public static List<TaxSlabsDto> ConvertTaxSlabsToDto(List<TaxSlab> taxSlabs)
        {
            var taxSlabsDto = from taxSlab in taxSlabs
                              select new TaxSlabsDto
                              {
                                  TaxPercent = taxSlab.TaxPercent,
                                  TaxSlabAmount = taxSlab.TaxSlabAmount,
                                  TaxSlabId = taxSlabs.Count,
                                  TaxYear = taxSlab.TaxYear
                              };
            return taxSlabsDto.ToList();
        }
        public static TaxRebate ConvertTaxRebateDtoToEntity(TaxRebateDto taxRebateDto)
        {
            if (taxRebateDto == null) return null;
            var taxRebate = new TaxRebate
            {
                FinYear = taxRebateDto.FinYear,
                Id = taxRebateDto.Id,
                RebateCode = taxRebateDto.RebateCode,
                RebateAmount = taxRebateDto.RebateAmount,
                RebateDesc = taxRebateDto.RebateDesc

            };
            return taxRebate;
        }
        private static List<TaxSlab> ConvertTaxSlabToEntity(List<TaxSlabsDto> taxSlabs)
        {
            var taxSlabsDto = from taxSlab in taxSlabs
                              select new TaxSlab
                              {
                                  TaxPercent = taxSlab.TaxPercent,
                                  TaxSlabAmount = taxSlab.TaxSlabAmount,
                                  TaxSlabId = taxSlabs.Count,
                                  TaxYear = taxSlab.TaxYear
                              };
            return taxSlabsDto.ToList();
        }
    }
}
