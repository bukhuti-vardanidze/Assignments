using Microsoft.AspNetCore.Mvc;
using PricingEngine_Api.Models.Request;
using PricingEngine_Api.Repositories;

namespace PricingEngine_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInputController : ControllerBase
    {
        private readonly IUserInputRepository _userInputRepository;
        private readonly ICalculationRepository _calculationRepository;

        public UserInputController(IUserInputRepository userInputRepository, ICalculationRepository calculationRepository)
        {
            _userInputRepository = userInputRepository;
            _calculationRepository = calculationRepository;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> getAllUserInput()
        {
            var result = await _userInputRepository.GetAllUserInputs();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> addUserInput(UserInputRequest userInput)
        {
            var result = await _userInputRepository.AddUserInput(userInput);
            return Ok(result);
        }

        [HttpPost("Calculate-Balance")]
        public async Task<IActionResult> CalculateInput(UserInputRequest userInput)
        {
            var result = await _calculationRepository.EndingBalance(userInput);
            return Ok(result);
        }

    }
}
