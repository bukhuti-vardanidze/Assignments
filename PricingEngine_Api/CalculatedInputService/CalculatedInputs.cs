using PricingEngine_Api.Db.Entities;
using PricingEngine_Api.Models;
using PricingEngine_Api.Models.Request;


namespace PricingEngine_Api.Services
{
    public class CalculatedInputs
    {

        public static CalculatedInput Calculate(UserInputRequest userInput, DataBaseInput dataBaseInput)
        {
            var InteresetRates = ((userInput.ProductType == "Loan" || userInput.ProductType == "CD") && userInput.InterestType == "Fixed") ? userInput.TeaserPeriod : (userInput.TeaserPeriod == 0 ? userInput.TeaserSpread / 100 : (userInput.InterestSpread + userInput.TeaserSpread) / 100);
            var TransactionCostRates = userInput.AvgMonthlyFeeIncome / (1 - (userInput.DiaxountFromStandardFee / 100));
            var CapitalAllcationRates = (dataBaseInput.CreditRiskAllocation == "Capital") ? (dataBaseInput.CapitalRiskRateWeight + dataBaseInput.MaintenanceRate) / 100 : dataBaseInput.MaintenanceRate / 100;
            var UsedPayment = (userInput.InterestType == "Fixed") ? userInput.Balance * (userInput.InterestSpread / 100) : userInput.Balance * (userInput.TeaserSpread / 100);

            var InputCalculate = new CalculatedInput
            {
                InterestRate = InteresetRates,
                TransactionCostRate = TransactionCostRates,
                CapitalAllcationRate = CapitalAllcationRates,
                UsedPayment = UsedPayment
            };

            return InputCalculate;
        }
    }
}
