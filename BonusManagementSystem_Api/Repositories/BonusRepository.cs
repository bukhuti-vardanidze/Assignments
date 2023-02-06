using BonusManagementSystem_Api.Db;
using BonusManagementSystem_Api.Db.Entity;
using BonusManagementSystem_Api.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Repositories
{  
    public interface IBonusRepository
    {
        Task<List<BonusEntity>> GetAllBonus();
        Task<List<BonusEntity>> GetBonusById(int BonusId);
        Task<BonusEntity> AddBonus(BonusRequest request);


    }
    public class BonusRepository : IBonusRepository
    {
        private readonly AppDbContext _db;

        public BonusRepository(AppDbContext db)
        {
            _db = db;
        }


        public async Task<List<BonusEntity>> GetAllBonus()
        {
            var result = await _db.bonuses.ToListAsync();
            return result;
            
        }


        public async Task<List<BonusEntity>> GetBonusById(int BonusId)
        {
            var result = await _db.bonuses.Where(x=>x.Id == BonusId).ToListAsync();
            return result;

        }


        public async Task<BonusEntity> AddBonus(BonusRequest request)
        {
            var employee = _db.employees.FirstOrDefault(x=>x.Id ==request.employeeId);
           
            var bonus = new BonusEntity()
            {
                Id = request.employeeId,
                BonusQuantity = request.BonusQuantity,
                BonusIssueTime = DateTime.Now
            };

            
            

            _db.bonuses.Add(bonus);
            await _db.SaveChangesAsync();
            return bonus;
        }
    }

  
}
