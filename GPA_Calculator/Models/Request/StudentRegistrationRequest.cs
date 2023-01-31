using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Models.Request
{
    public class StudentRegistrationRequest
    {
        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PersonalNumber { get; set; }
        [Required]
        public string CourseName { get; set; }
    }
}
