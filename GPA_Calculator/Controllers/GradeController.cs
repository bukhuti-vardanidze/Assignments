using GPA_Calculator.Models.Request;
using GPA_Calculator.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GPA_Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradeController:ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;

       public GradeController(IGradeRepository gradeRepository) 
        {
            _gradeRepository=gradeRepository;
        }


        [HttpGet("Get-All-Grade")]
        public async Task<IActionResult> GetAllGrade()
        {
            var result = await _gradeRepository.GetAllGrade();
            if(result == null)
            {
                return NotFound("grade info not found");
            }
            return Ok(result);
        }

        [HttpGet("Get-Single-Grade")]
        public async Task<IActionResult> GetSingleGrade(int gradeId)
        {
            var result = await _gradeRepository.GetSingleGradeById(gradeId);
            if (result == null)
            {
              return NotFound("grade info not found");
            }

           
            
            return Ok(result);
        }

        [HttpPost("Add-Grade")]
        public async Task<IActionResult> AddGrade([FromBody]GradeRegisterRequest request, int id)
        {
            var result = await _gradeRepository.AddGrade(request,id);
            if (result == null)
            {
                return NotFound("grade info not found");
            }
            return Ok(result);
        }


      


    }
}
