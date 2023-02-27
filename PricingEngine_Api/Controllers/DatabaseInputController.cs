using Microsoft.AspNetCore.Mvc;
using PricingEngine_Api.Db.Entities;
using PricingEngine_Api.Models.Request;
using PricingEngine_Api.Repositories;

namespace PricingEngine_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseInputController : ControllerBase
    {
        private readonly IDataBaseInputRepository _dataBaseInputRepository;

        public DatabaseInputController(IDataBaseInputRepository dataBaseInputRepository)
        {
            _dataBaseInputRepository = dataBaseInputRepository;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> getAllDbInput()
        {
            var result = await _dataBaseInputRepository.GetAllDBInputsAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDbInputs(DataBaseInputRequest input)
        {
            var result = await _dataBaseInputRepository.addDbInput(input);
            return Ok(result);
        }

    }
}
