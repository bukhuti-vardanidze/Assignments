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

 public async Task<ActionResult<List<>>

    }
}
