using BonusManagementSystem_Api.Db;
using BonusManagementSystem_Api.Db.Entity;
using BonusManagementSystem_Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Repositories
{  
    public interface IBonusRepository
    {
        Task SaveChange();
        Task<List<BonusEntity>> GetAllBonus();
        Task<List<BonusEntity>> GetBonusById(int BonusId);
        //Task/*<BonusEntity>*/ AddBonus(BonusRequest request);
        Task giveBonus(int employeeId, double bonusAmount);

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


        //public async Task/*<BonusEntity>*/ AddBonus(BonusRequest request)
        //{
        //    var employee = _db.employees.FirstOrDefault(x=>x.Id == request.EmployeeId);
           
        //    var bonus_1 = new BonusEntity()
        //    {
        //        Id = request.EmployeeId,
        //        BonusQuantity = request.BonusQuantity,
        //        BonusIssueTime = DateTime.Now
        //    };
            
        //    var result = await  _db.bonuses.AddAsync(bonus_1);
        //     employee.BonusEntity.Add(bonus_1);
        //    _db.employees.Update(employee);
            
        //  if(employee.RecomedatorId != 0)
        //    {
        //        var employee_2 = await _db.employees.FirstOrDefaultAsync(x=>x.Id==employee.RecomedatorId);
        //        var bonus_2 = new BonusEntity()
        //        {
        //            Id = request.EmployeeId,
        //            BonusQuantity = request.BonusQuantity / 2,
        //            BonusIssueTime = DateTime.Now
        //        };

        //        await _db.bonuses.AddAsync(bonus_2);
        //        employee_2.BonusEntity.Add(bonus_2);
        //        _db.employees.Update(employee_2);


        //        if (employee_2.RecomedatorId != 0)
        //        {
        //            var employee_3 = await _db.employees.FirstOrDefaultAsync(x => x.Id == employee_2.RecomedatorId);
        //            var bonus_3 = new BonusEntity()
        //            {
        //                Id = request.EmployeeId,
        //                BonusQuantity = request.BonusQuantity / 4,
        //                BonusIssueTime = DateTime.Now
        //            };
                    
        //            await _db.bonuses.AddAsync(bonus_3);
        //            employee_3.BonusEntity.Add(bonus_3);
        //            _db.employees.Update(employee_3);


        //            if (employee_3.RecomedatorId != 0)
        //            {
        //                var employee_4 = await _db.employees.FirstOrDefaultAsync(x => x.Id == employee_3.RecomedatorId);
        //                var bonus_4 = new BonusEntity()
        //                {
        //                    Id = request.EmployeeId,
        //                    BonusQuantity = request.BonusQuantity * 0,
        //                    BonusIssueTime = DateTime.Now
        //                };

        //                await _db.bonuses.AddAsync(bonus_4);
        //                employee_4.BonusEntity.Add(bonus_4);
        //                _db.employees.Update(employee_4);

        //            }
                    

        //        }

        //    }

        //   // return result.Entity;
        //}
        


        public async Task giveBonus(int employeeId, double bonusAmount)
        {
            var employee = await _db.employees.FindAsync(employeeId);
          
            double employeeBonus = employee.Salary * bonusAmount;
            employee.Salary += employeeBonus;

            if(employee.RecomedatorId != null)
            {
                var recommender =await _db.employees.FindAsync(employee.RecomedatorId);
                if(recommender!= null)
                {
                    double recommenderBonus = employeeBonus / 2;
                    recommender.Salary += recommenderBonus;
                    if(recommender.RecomedatorId != null)
                    {
                        var recommender2 = await _db.employees.FindAsync(recommender.RecomedatorId);
                        if(recommender2 != null)
                        {
                            double recomender2Bonus = recommenderBonus/ 2; 
                            recommender2.Salary += recomender2Bonus;
                        }
                    }
                }
            }
            

        }
        



        public async Task SaveChange()
        {
            await _db.SaveChangesAsync();
        }

    }

  
}
