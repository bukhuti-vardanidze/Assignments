namespace PricingEngine_Api.Db.Entities
{
    public class UserInput
    {
        public int UserInputId { get; set; }
        public decimal Balance { get; set; }
        public string InterestType { get; set; }
        public string ProductType { get; set; }
        public string PaymentType { get; set; }
        public int OriginalTermInMonths { get; set; }
        public decimal CommitmentAmount { get; set; }
        public decimal MonthlyFeeIncome { get; set; }
        public decimal InterestSpread { get; set; }
        public int TeaserPeriod { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TeaserSpread { get; set; }
        public int AvgMonthlyFeeIncome { get; set; }
        public decimal DiaxountFromStandardFee { get; set; }
    }
}
