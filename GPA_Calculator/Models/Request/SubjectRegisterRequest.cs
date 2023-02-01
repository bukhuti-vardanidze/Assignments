using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Models.Request
{
    public class SubjectRegisterRequest
    {
      
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int Credits { get; set; }

    }
}
