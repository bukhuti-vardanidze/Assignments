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

        [HttpPost("students/{studentid}/Grade")]
        public async Task<IActionResult> AddGrade([FromBody] GradeRegisterRequest request)
        {
            var result = await _gradeRepository.AddGrade(request);
            if (result == null)
            {
                return NotFound("grade info not found");
            }
            return Ok(result);
        }



        












        //[HttpGet("get-data")]
        //public IActionResult GetData()
        //{
        //    var result = from t1 in _context.StudentDb.ToList()
        //                 join t2 in _context.GradeDb on t1.Id equals t2.Id
        //                 select new { t1.PersonalNumber, t2.Score };
            
        //    return Ok(result);
        //}
        

    }
}
