namespace EmployeeManagement.Domain.Entities
{
    public class TaxDeductions
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public List<TaxSlabs> TaxTypes { get; set; }
        public List<TaXRebateCode> TaxRebate { get; set; }
    }

    public class TaXRebateCode
    {
        public int Id { get; set; }
        public string RebateCode { get; set; }
        public int RebateAmount { get; set; }
    }

    public class TaxSlabs
    {
        public int TaxSlabId { get; set; }
        public int TaxSlabAmount { get; set; }
        public float TaxPercent {  get; set; }
        public int TaxValue { get; set; }
    }
}
