using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Models.Request
{
    public class SubjectRegisterRequest
    {
      
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }

    }
}
