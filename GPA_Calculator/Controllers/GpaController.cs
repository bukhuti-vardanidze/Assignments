using GPA_Calculator.Calculate_GPA;
using GPA_Calculator.Db;
using GPA_Calculator.Models.Request;
using GPA_Calculator.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GPA_Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GpaController :ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
       

        public GpaController(IGradeRepository gradeRepository, IStudentRepository studentRepository, ISubjectRepository subjectRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
           
            
        }

        [HttpPost("student-register")]
        public async Task<IActionResult> StudentRegister([FromBody] StudentRegistrationRequest request)
        {
            var result = await _studentRepository.StudentRegisterAsync(request);

            return Ok(result);
        }

        [HttpPost("Subject-register")]
        public async Task<IActionResult> SubjectRegister([FromBody] SubjectRegisterRequest request)
        {
            var result = await _subjectRepository.AddSubjectAsync(request);
            return Ok(result);
        }

        [HttpPost("students/Grade-register")]
        public async Task<IActionResult> AddGrade([FromBody] GradeRegisterRequest request)
        {
            var result = await _gradeRepository.AddGrade(request);
            if (result == null)
            {
                return NotFound("grade info not found");
            }
            return Ok(result);
        }


        [HttpGet("students/{gradeId}/Get-Grade")]
        public async Task<IActionResult> GetScoreFromResult(int gradeId)
        {
            var result = await _gradeRepository.GetStudentScoreById(gradeId);
            if (result == null)
            {
                return NotFound("grade info not found");
            }

            return Ok(result);
        }

        [HttpGet("Calculate-GPA")]
        public async Task<IActionResult> GPACalculator(int studentID)
        {
            var grades = await _gradeRepository.GetStudnetGradeById(studentID);
            var calculator = new GPACalcutor();
            var GPA = calculator.Calculator(grades);
            return Ok(GPA);
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

       


    }
}
