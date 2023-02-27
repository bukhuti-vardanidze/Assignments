using Microsoft.EntityFrameworkCore;
using PricingEngine_Api.Services;
using PricingEngine_Api.Db;
using PricingEngine_Api.Db.Entities;
using PricingEngine_Api.Models;
using PricingEngine_Api.Models.Request;


namespace PricingEngine_Api.Repositories
{
    public interface ICalculationRepository
    {
        Task<decimal> EndingBalance(UserInputRequest userInput);
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
            var TotalBalanceS = userInput.Balance;
            for (int j = 2; j < 14; j++)
            {
                var CalculateK = (calculatedInput.UsedPayment * j) + (calculatedInput.UsedPayment * (dataBaseInput.MaintenanceRate / 100)) + (userInput.InterestType == "Variable" ? userInput.CommitmentAmount * userInput.MonthlyFeeIncome : 0);
                var CalculateL = (userInput.PaymentType == "Interest only" || userInput.PaymentType == "Principal Interest") ? (CalculateK * (userInput.InterestSpread / 100)) + (CalculateK * (userInput.InterestSpread / 100) * calculatedInput.InterestRate) : userInput.CommitmentAmount + userInput.MonthlyFeeIncome + (CalculateK * (userInput.InterestSpread / 100));
                var CalculateM = (-(CalculateK - CalculateL) > TotalBalanceS) ? -TotalBalanceS : Math.Min(0, CalculateK - CalculateL);
                var CalculateN = (j >= userInput.OriginalTermInMonths) ? -CalculateL : 0;
                var CalculateO = CalculateM + CalculateN;
                var CalculateP = (-CalculateO >= TotalBalanceS) ? 0 : Math.Max(-(TotalBalanceS + CalculateO), -(dataBaseInput.PrepaymentRate / 100) * TotalBalanceS);
                var CalculateQ = CalculateO + CalculateP + (CalculateP * calculatedInput.CapitalAllcationRate);
                var CalculateR = CalculateQ * calculatedInput.InterestRate;
                var totalT = TotalBalanceS + CalculateQ;
                CalculateTotalBalance += totalT;
                TotalBalanceS = totalT;

            }
            return CalculateTotalBalance;

        }

        public async Task<decimal> EndingBalance(UserInputRequest userInput)
        {
            var TakeDabaseInput = await _db.DataBaseInputs.FirstOrDefaultAsync();
            CalculatedInput calculatedInput = CalculatedInputs.Calculate(userInput, TakeDabaseInput);

            var EndingBalance = CalculateTotalBalance(userInput, TakeDabaseInput, calculatedInput);
            return EndingBalance;
        }

    }

}
