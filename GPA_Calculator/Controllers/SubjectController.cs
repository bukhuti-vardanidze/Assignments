using GPA_Calculator.Models.Request;
using GPA_Calculator.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace GPA_Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public    SubjectController(ISubjectRepository subjectRepository) 
        {
            _subjectRepository = subjectRepository;
        }


        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject()
        {
            var result = await _subjectRepository.GetAllSubjectAsync();
            if (result == null)
            {
                return NotFound("Subject Not Found");
            }
            return Ok(result);
        }


        [HttpGet("GetSingleSubject")]
        public async Task<IActionResult> GetSingleSubjectSubject(int subjectId)
        {
            var result = await _subjectRepository.GetSingleSubjectAsync(subjectId);
            if (result == null)
            {
                return NotFound("Subject not found");
            }
            return Ok(result);
        }



        [HttpPost("Subject-register")]
        public async Task<IActionResult> SubjectRegister([FromBody] SubjectRegisterRequest request)
        {
            var result = await _subjectRepository.AddSubjectAsync(request);
            return Ok(result);
        }


        [HttpGet("get-top-3-subject-Avearge-score")]
        public async Task<IActionResult> GetTop3SubjectAverageScore()
        {
            var result = await _subjectRepository.GetTop3EasySubject();
            return Ok(result);
        }


        [HttpGet("get-last-3-subject-Average-score")]
        public async Task<IActionResult> GetLast3SubjectAverageScore()
        {
            var result = await _subjectRepository.GetLast3HardSubject();
            return Ok(result);
        }


        [HttpGet("GET-GPA")]
        public async Task<IActionResult> CalculateGPA(double studentID)
        {
            var result = await _subjectRepository.GetGPA(studentID);
            return Ok(result);
        }

    }
}
