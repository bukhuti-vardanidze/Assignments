using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Models.Request
{
    public class GradeRegisterRequest
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100")]
        public int Score { get; set; }
    }
}
