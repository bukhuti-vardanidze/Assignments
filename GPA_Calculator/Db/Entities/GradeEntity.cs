using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Db.Entities
{
    public class GradeEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int Score { get; set; }

    }
}
