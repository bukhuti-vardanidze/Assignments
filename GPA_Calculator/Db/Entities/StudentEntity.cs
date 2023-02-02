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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string CourseName { get; set; }
    }
}
