using BonusManagementSystem_Api.Db;
using BonusManagementSystem_Api.Db.Entity;
using BonusManagementSystem_Api.Models;
using BonusManagementSystem_Api.Models.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BonusManagementSystem_Api.Repositories
{  
    public interface IBonusRepository
    {
     
        Task<List<BonusEntity>> GetAllBonus();
        Task<List<BonusEntity>> GetBonusById(int BonusId);
        Task<BonusEntity> AddBonus(int EmployeeId, double bonus);
        Task SaveChangeAsync();

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
            var result = await _db.Bonuses.ToListAsync();
            return result;
            
            
        }


        public async Task<List<BonusEntity>> GetBonusById(int BonusId)
        {
            var result = await _db.Bonuses.Where(x=>x.Id == BonusId).ToListAsync();
            return result;

        }



        public async Task<BonusEntity> AddBonus(int EmployeeId, double bonus)
        {
            var employee = _db.Employees.FirstOrDefault(x => x.Id == EmployeeId);

            var calculate_bonus_1 = bonus;
            var calculate_bonus_2 = calculate_bonus_1 / 2;
            var calculate_bonus_3 = calculate_bonus_2 / 2;


            var bonus_1 = new BonusEntity()
            {
                Id = EmployeeId,
                BonusQuantity = calculate_bonus_1,
                BonusIssueTime = DateTime.Now
            };

            var result = await _db.Bonuses.AddAsync(bonus_1);


            if (employee.RecomedatorId != 0)
            {
                var employee_2 = await _db.Employees.FirstOrDefaultAsync(x => x.Id == employee.RecomedatorId);
                var bonus_2 = new BonusEntity()
                {
                    Id = employee_2.Id,
                    BonusQuantity = calculate_bonus_2,
                    BonusIssueTime = DateTime.UtcNow
                };

                await _db.Bonuses.AddAsync(bonus_2);


                if (employee_2.RecomedatorId != 0)
                {
                    var employee_3 = await _db.Employees.FirstOrDefaultAsync(x => x.Id == employee_2.RecomedatorId);
                    var bonus_3 = new BonusEntity()
                    {
                        Id = employee_3.Id,
                        BonusQuantity = calculate_bonus_3,
                        BonusIssueTime = DateTime.UtcNow
                    };

                    await _db.Bonuses.AddAsync(bonus_3);


                }
            }

            return result.Entity;

        }




      

       


        public async Task SaveChangeAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
