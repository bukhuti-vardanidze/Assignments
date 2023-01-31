using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Db.Entities
{
    public class SubjectEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int Credits { get; set; }
       

    }
}
