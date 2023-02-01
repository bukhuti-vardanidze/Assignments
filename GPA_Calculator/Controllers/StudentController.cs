using GPA_Calculator.Db.Entities;
using GPA_Calculator.Models.Request;
using GPA_Calculator.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GPA_Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var result = await _studentRepository.GetAllStudentsAsync();
            if(result == null)
            {
                return NotFound("students not found");
            }
            return Ok(result);
        }


        [HttpGet("GetSingleStudentById")]
        public async Task<IActionResult> GetSingleStudent(int studentId)
        {
            var result = await _studentRepository.GetSingleStudentAsync(studentId);
            if (result == null)
            {
                return NotFound("students not found");
            }
            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> StudentRegister([FromBody] StudentRegistrationRequest  request)
        {
            var result = await _studentRepository.StudentRegisterAsync(request);
            
            return Ok(result);
        }

    }
}
