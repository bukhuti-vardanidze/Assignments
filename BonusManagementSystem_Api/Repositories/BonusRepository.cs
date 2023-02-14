using BonusManagementSystem_Api.Db;
using BonusManagementSystem_Api.Db.Entity;
using BonusManagementSystem_Api.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Repositories
{  
    public interface IBonusRepository
    {
        Task SaveChange();
        Task<List<BonusEntity>> GetAllBonus();
        Task<List<BonusEntity>> GetBonusById(int BonusId);
        Task/*<BonusEntity>*/ AddBonus(BonusRequest request);

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


        public async Task/*<BonusEntity>*/ AddBonus(BonusRequest request)
        {
            var employee = _db.employees.FirstOrDefault(x=>x.Id == request.EmployeeId);
           
            var bonus_1 = new BonusEntity()
            {
                Id = request.EmployeeId,
                BonusQuantity = request.BonusQuantity,
                BonusIssueTime = DateTime.Now
            };
            
            var result = await  _db.bonuses.AddAsync(bonus_1);
             employee.Bonus.Add(bonus_1);
            _db.employees.Update(employee);
            
          if(employee.RecomedatorId != 0)
            {
                var employee_2 = await _db.employees.FirstOrDefaultAsync(x=>x.Id==employee.RecomedatorId);
                var bonus_2 = new BonusEntity()
                {
                    Id = request.EmployeeId,
                    BonusQuantity = request.BonusQuantity / 2,
                    BonusIssueTime = DateTime.Now
                };

                await _db.bonuses.AddAsync(bonus_2);
                employee_2.Bonus.Add(bonus_2);
                _db.employees.Update(employee_2);


                if (employee_2.RecomedatorId != 0)
                {
                    var employee_3 = await _db.employees.FirstOrDefaultAsync(x => x.Id == employee_2.RecomedatorId);
                    var bonus_3 = new BonusEntity()
                    {
                        Id = request.EmployeeId,
                        BonusQuantity = request.BonusQuantity / 4,
                        BonusIssueTime = DateTime.Now
                    };
                    
                    await _db.bonuses.AddAsync(bonus_3);
                    employee_2.Bonus.Add(bonus_3);
                    _db.employees.Update(employee_3);


                    if (employee_3.RecomedatorId != 0)
                    {
                        var employee_4 = await _db.employees.FirstOrDefaultAsync(x => x.Id == employee_3.RecomedatorId);
                        var bonus_4 = new BonusEntity()
                        {
                            Id = request.EmployeeId,
                            BonusQuantity = request.BonusQuantity * 0,
                            BonusIssueTime = DateTime.Now
                        };

                        await _db.bonuses.AddAsync(bonus_4);
                        employee_2.Bonus.Add(bonus_4);
                        _db.employees.Update(employee_4);

                    }
                    

                }

            }

           // return result.Entity;
        }

       
        

        public async Task SaveChange()
        {
            await _db.SaveChangesAsync();
        }

    }

  
}
