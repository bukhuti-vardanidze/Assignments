using BonusManagementSystem_Api.Db;
using BonusManagementSystem_Api.Db.Entity;
using BonusManagementSystem_Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> GetAllEmployee();
        Task<List<EmployeeEntity>> GetEmployeeById(int EmployeeId);
        Task<EmployeeEntity> RegisterEmployee(EmployeeRequest request);
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
                RecomedatorId= x.RecomedatorId,
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
                RecomedatorId = x.RecomedatorId,
                Salary = x.Salary,
                StartDate = DateTime.UtcNow
            }).ToListAsync();
            return result;

        }

        public async Task<EmployeeEntity> RegisterEmployee(EmployeeRequest request)
        {
            var result = new EmployeeEntity
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PrivateNumber = request.PrivateNumber,
                RecomedatorId = request.RecomedatorId,
                Salary = request.Salary,
                StartDate = DateTime.UtcNow
            };
         
            _db.employees.Add(result);
            await _db.SaveChangesAsync();
            return result;
           

        }

        

    }

    
}
