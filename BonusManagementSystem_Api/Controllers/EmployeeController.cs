using BonusManagementSystem_Api.Db.Entity;
using BonusManagementSystem_Api.Models.Requests;
using BonusManagementSystem_Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BonusManagementSystem_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
       public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository=employeeRepository;
        }


        [HttpGet("get-employee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _employeeRepository.GetAllEmployee();
            if (result == null)
            {
                return NotFound("Employee Not Found");
            }
            return Ok(result);
        }

        [HttpGet("get-employee/{EmployeeId}")]
        public async Task<IActionResult> GetEmployeeById(int EmployeeId)
        {
            var result = await _employeeRepository.GetEmployeeById(EmployeeId);
            if(result == null)
            {
                return NotFound("Employee Not Found");
            }
            return Ok(result);
            
        }

        [HttpPost("Register-Employee")]
        public async Task<IActionResult> RegisterEmployee(EmployeeRequest request)
        {
            var result = await _employeeRepository.RegisterEmployee(request);
          
            return Ok(result);
        }


        [HttpPost("Update-Employee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeRequest request)
        {
            var result = await _employeeRepository.UpdateEmployee(request);
            
            return Ok(result);
        }

       

    }
}
