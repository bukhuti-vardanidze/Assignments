using BonusManagementSystem_Api.Models.Requests;
using BonusManagementSystem_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BonusManagementSystem_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BonusController :ControllerBase
    {
        private readonly IBonusRepository _bonusRepository;
        public BonusController(IBonusRepository bonusRepository)
        {
            _bonusRepository = bonusRepository;
        }

        [HttpGet("get-All-Bonus")]
        public async Task<IActionResult> GetAllBonus()
        {
            var result = await _bonusRepository.GetAllBonus();
            if (result == null)
            {
                return NotFound("Employee Not Found");
            }
            return Ok(result);
        }

        [HttpGet("get-Bonus/{BonusId}")]
        public async Task<IActionResult> GetEmployeeById(int BonusId)
        {
            var result = await _bonusRepository.GetBonusById(BonusId);
            if (result == null)
            {
                return NotFound("Employee Not Found");
            }
            return Ok(result);

        }

        [HttpPost("Add-Bonus")]
        public async Task<IActionResult> RegisterEmployee(BonusRequest request)
        {
            var result = await _bonusRepository.AddBonus(request);

            return Ok(result);
        }
    }
}
