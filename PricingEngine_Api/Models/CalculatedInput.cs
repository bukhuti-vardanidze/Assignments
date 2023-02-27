namespace PricingEngine_Api.Models
{
    public class CalculatedInput
    {
        public decimal InterestRate { get; set; }
        public decimal TransactionCostRate { get; set; }
        public decimal CapitalAllcationRate { get; set; }
        public decimal UsedPayment { get; set; }
    }
}
