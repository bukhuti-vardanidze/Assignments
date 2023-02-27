using System.ComponentModel.DataAnnotations;

namespace PricingEngine_Api.Db.Entities
{
    public class DataBaseInput
    {
        [Key]
        public int DataBaseInputId { get; set; }
        public decimal MaintenanceRate { get; set; }
        public decimal PrepaymentRate { get; set; }
        public string CreditRiskAllocation { get; set; }
        public decimal CapitalRiskRateWeight { get; set; }


    }
}
