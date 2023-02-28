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
      

        public UserInputController(IUserInputRepository userInputRepository)
        {
            _userInputRepository = userInputRepository;
           
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
       

    }
}
