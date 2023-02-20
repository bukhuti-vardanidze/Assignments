using BonusManagementSystem_Api.Db;
using BonusManagementSystem_Api.Db.Entity;
using BonusManagementSystem_Api.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Repositories
{
    public interface IStatisticRepository
    {
        Task<int> BonusCountInSomePeriodAsync(DateTime startDate, DateTime endDate);
        Task<List<EmployeeEntity>> Top10EmployeesWithMostBonuses();
        Task<List<BonusRequest>> GetTop10Recomendator();
        Task SaveChangeAsync();
    }

    public class StatisticRepository : IStatisticRepository
    {
        private readonly AppDbContext _db;

        public StatisticRepository(AppDbContext db) 
        { 
            _db= db;
        }


        public async Task<int> BonusCountInSomePeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _db.Bonuses
                .Where(x => x.BonusIssueTime.Month >= startDate.Month && x.BonusIssueTime.Month <= endDate.Month)
                .CountAsync();
        }

        public async Task<List<EmployeeEntity>> Top10EmployeesWithMostBonuses()
        {
            var result= await _db.Employees.Include(e => e.BonusEntity)
                .OrderByDescending(e => e.BonusEntity.Sum(b => b.BonusQuantity))
                .Take(10).ToListAsync();
            return result;
        }

        public async Task<List<BonusRequest>> GetTop10Recomendator()
        {
            var result = await _db.Employees.Where(x => x.RecomedatorId != 0)
                         .Join(_db.Bonuses, x => x.Id, y => y.EmployeeId, (x, y) => new { x, y }).GroupBy(z => z.x.RecomedatorId)
                         .Select(k => new BonusRequest
                         {
                             RecomendatorId = k.Key,
                             countBonus = k.Count(),
                             BonusAmount = k.Sum(x => x.y.BonusQuantity)
                         })
                         .Take(10)
                         .OrderByDescending(x => x.BonusAmount)
                         .ToListAsync();
            return result;
        }

        public async Task SaveChangeAsync()
        {
            await _db.SaveChangesAsync();
        }
    }

}
