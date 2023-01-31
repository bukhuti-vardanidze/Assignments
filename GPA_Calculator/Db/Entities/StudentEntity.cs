using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Db.Entities
{
    //public enum StudentCourse
    //{
    //    FirstYear = 1 ,
    //    SecondYear = 2 ,
    //    ThirdYear = 3,
    //    FourthYear = 4
    //}
    public class StudentEntity
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
