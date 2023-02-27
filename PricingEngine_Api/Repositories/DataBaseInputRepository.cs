using Microsoft.EntityFrameworkCore;
using PricingEngine_Api.Db;
using PricingEngine_Api.Db.Entities;
using PricingEngine_Api.Models.Request;

namespace PricingEngine_Api.Repositories
{
    public interface IDataBaseInputRepository
    {
        Task<List<DataBaseInput>> GetAllDBInputsAsync();
        Task<DataBaseInput> addDbInput(DataBaseInputRequest input);
    }
    public class DataBaseInputRepository : IDataBaseInputRepository
    {
        private readonly AppDbContext _db;

        public DataBaseInputRepository(AppDbContext db)
        {
            _db = db;
        }


        public async Task<List<DataBaseInput>> GetAllDBInputsAsync()
        {
            return await _db.DataBaseInputs.ToListAsync();
        }

        public async Task<DataBaseInput> addDbInput(DataBaseInputRequest input)
        {
            var result = new DataBaseInput()
            {
                DataBaseInputId = input.DataBaseInputId,
                MaintenanceRate = input.MaintenanceRate,
                PrepaymentRate = input.PrepaymentRate,
                CreditRiskAllocation = input.CreditRiskAllocation,
                CapitalRiskRateWeight = input.CapitalRiskRateWeight
            };
            _db.DataBaseInputs.Add(result);
            await _db.SaveChangesAsync();
            return result;
        }
        
    }
}
