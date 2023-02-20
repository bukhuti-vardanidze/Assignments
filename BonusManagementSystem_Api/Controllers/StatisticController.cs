using BonusManagementSystem_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BonusManagementSystem_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;
        private readonly IBonusRepository _bonusRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public StatisticController(IStatisticRepository statisticRepository, IBonusRepository bonusRepository, IEmployeeRepository employeeRepository)
        {
            _statisticRepository = statisticRepository;
            _bonusRepository = bonusRepository;
            _employeeRepository = employeeRepository;

        }

        [HttpGet("Count-Bonus-InSomePeriod-(Month)")]
        public async Task<IActionResult> GetBonusCount(DateTime? startDate,DateTime? endDate)
        {
 
            var result = await _statisticRepository.BonusCountInSomePeriodAsync(startDate.Value, endDate.Value);
            return Ok(result);
        }

        [HttpGet("Top10-Employee-WithMostBonuses")]
        public async Task<IActionResult> top10emp()
        {
            var result = await _statisticRepository.Top10EmployeesWithMostBonuses();
            return Ok(result);
        }

        [HttpGet("Top10-recomendator-WithMostBonuses")]
        public async Task<IActionResult> top10recom()
        {
            var result = await _statisticRepository.GetTop10Recomendator();
            return Ok(result);
        }
    }
}
