using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PricingEngine_Api.Models.Request;
using PricingEngine_Api.Repositories;

namespace PricingEngine_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationRepository _calculationRepository;

        public CalculationController(ICalculationRepository calculationRepository) 
        {
            _calculationRepository = calculationRepository;
        }


        [HttpPost("Calculate-Balance")]
        public async Task<IActionResult> CalculateInput(UserInputRequest userInput, int dbId)
        {
            var result = await _calculationRepository.EndingBalance(userInput,dbId);
            return Ok(result);
        }
    }
}
