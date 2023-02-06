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
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("get-employee/{EmployeeId}")]
        public async Task<IActionResult> GetEmployeeById(int EmployeeId)
        {
            var result = await _employeeRepository.GetEmployeeById(EmployeeId);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
            
        }


    }
}
