using Microsoft.EntityFrameworkCore;
using PricingEngine_Api.Db;
using PricingEngine_Api.Db.Entities;
using PricingEngine_Api.Models.Request;

namespace PricingEngine_Api.Repositories
{
    public interface IUserInputRepository
    {
        Task<List<UserInput>> GetAllUserInputs();
        Task<UserInput> AddUserInput(UserInputRequest userInput);
    }
    public class UserInputRepository : IUserInputRepository
    {
        private readonly AppDbContext _db;

        public UserInputRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserInput>> GetAllUserInputs()
        {
            return await _db.UserInputs.ToListAsync();
        }

        public async Task<UserInput> AddUserInput(UserInputRequest userInput)
        {
            var result = new UserInput()
            {
                Balance = userInput.Balance,
                InterestType = userInput.InterestType,
                ProductType = userInput.ProductType,
                PaymentType = userInput.PaymentType,
                OriginalTermInMonths = userInput.OriginalTermInMonths,
                CommitmentAmount = userInput.CommitmentAmount,
                MonthlyFeeIncome = userInput.MonthlyFeeIncome,
                InterestSpread = userInput.InterestSpread,
                TeaserPeriod = userInput.TeaserPeriod,
                InterestRate = userInput.InterestRate,
                TeaserSpread = userInput.TeaserSpread,
                AvgMonthlyFeeIncome = userInput.AvgMonthlyFeeIncome,
                DiaxountFromStandardFee = userInput.DiaxountFromStandardFee
            };
            _db.UserInputs.Add(result);
            await _db.SaveChangesAsync();
            return result;
        }
    }
}