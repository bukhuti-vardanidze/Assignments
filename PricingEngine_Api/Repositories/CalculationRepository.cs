using Microsoft.EntityFrameworkCore;
using PricingEngine_Api.CalculatedInputsServices;
using PricingEngine_Api.Db;
using PricingEngine_Api.Db.Entities;
using PricingEngine_Api.Models;
using PricingEngine_Api.Models.Request;


namespace PricingEngine_Api.Repositories
{
    public interface ICalculationRepository
    {
        Task<decimal> EndingBalance(UserInputRequest userInput, int dbId);
    }

    public class CalculationRepository : ICalculationRepository
    {
        private readonly AppDbContext _db;

        public CalculationRepository(AppDbContext db)
        {
            _db = db;
        }

        private decimal CalculateTotalBalance(UserInputRequest userInput, DataBaseInput dataBaseInput, CalculatedInput calculatedInput)
        {
            decimal CalculateTotalBalance = 0;
            var BeginingBalance = userInput.Balance;
            for (int Index = 2; Index < 14; Index++)
            {
                var CalculatePaymentAmount = (calculatedInput.UsedPayment * Index) + (calculatedInput.UsedPayment * (dataBaseInput.MaintenanceRate / 100)) + (userInput.InterestType == "Variable" ? userInput.CommitmentAmount * userInput.MonthlyFeeIncome : 0);
                var CalculateContractualInterest = (userInput.PaymentType == "Interest only" || userInput.PaymentType == "Principal Interest") ? (CalculatePaymentAmount * (userInput.InterestSpread / 100)) + (CalculatePaymentAmount * (userInput.InterestSpread / 100) * calculatedInput.InterestRate) : userInput.CommitmentAmount + userInput.MonthlyFeeIncome + (CalculatePaymentAmount * (userInput.InterestSpread / 100));
                var CalculateContractualPrincipal = (-(CalculatePaymentAmount - CalculateContractualInterest) > BeginingBalance) ? -BeginingBalance : Math.Min(0, CalculatePaymentAmount - CalculateContractualInterest);
                var CalculateBaloonPaymentAtMaturity = (Index >= userInput.OriginalTermInMonths) ? -CalculateContractualInterest : 0;
                var CalculateTotalContractualCashflow = CalculateContractualPrincipal + CalculateBaloonPaymentAtMaturity;
                var CalculatePrepaymentCashflow = (-CalculateTotalContractualCashflow >= BeginingBalance) ? 0 : Math.Max(-(BeginingBalance + CalculateTotalContractualCashflow), -(dataBaseInput.PrepaymentRate / 100) * BeginingBalance);
                var CalculateTotalPrincipalPaid = CalculateTotalContractualCashflow + CalculatePrepaymentCashflow + (CalculatePrepaymentCashflow * calculatedInput.CapitalAllcationRate);
                var CalculateAnnualaizedInterestOnCashFlow = CalculateTotalPrincipalPaid * calculatedInput.InterestRate;
                var CalculateEndingBalance = BeginingBalance + CalculateTotalPrincipalPaid;
                CalculateTotalBalance += CalculateEndingBalance;
            }
            return CalculateTotalBalance;
        }

        public async Task<decimal> EndingBalance(UserInputRequest userInput, int dbId)
        {
            var TakeDabaseInput = await _db.DataBaseInputs.Where(x=>x.DataBaseInputId == dbId).FirstOrDefaultAsync();
            var calculatedInput = CalculatedInputs.Calculate(userInput, TakeDabaseInput);

            var EndingBalance = CalculateTotalBalance(userInput, TakeDabaseInput, calculatedInput);
            return EndingBalance;
        }

    }

}
