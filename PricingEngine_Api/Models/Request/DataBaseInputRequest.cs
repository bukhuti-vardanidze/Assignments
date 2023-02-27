using System.ComponentModel.DataAnnotations;

namespace PricingEngine_Api.Models.Request
{
    public class DataBaseInputRequest
    {
        
        public int DataBaseInputId { get; set; }
        public decimal MaintenanceRate { get; set; }
        public decimal PrepaymentRate { get; set; }
        public string CreditRiskAllocation { get; set; }
        public decimal CapitalRiskRateWeight { get; set; }
    }
}
