using BonusManagementSystem_Api.Db;
using BonusManagementSystem_Api.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> GetAllEmployee();
        Task<List<EmployeeEntity>> GetEmployeeById(int EmployeeId);
    }


    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext db) 
        {
            _db = db;
        }


        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {
            var result =await _db.employees.Select( x => new EmployeeEntity()
            {
                Id= x.Id,
                FirstName= x.FirstName,
                LastName = x.LastName,
                PrivateNumber= x.PrivateNumber,
                Recomedator= x.Recomedator,
                Salary  = x.Salary,
                StartDate= DateTime.UtcNow
            }).ToListAsync();
            return result;
            
        }

        public async Task<List<EmployeeEntity>> GetEmployeeById(int EmployeeId)
        {
            var result = await _db.employees.Where(x=>x.Id == EmployeeId).Select(x => new EmployeeEntity()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PrivateNumber = x.PrivateNumber,
                Recomedator = x.Recomedator,
                Salary = x.Salary,
                StartDate = DateTime.UtcNow
            }).ToListAsync();
            return result;

        }



    }

    
}
