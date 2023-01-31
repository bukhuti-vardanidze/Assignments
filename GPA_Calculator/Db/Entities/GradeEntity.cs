namespace GPA_Calculator.Db.Entities
{
    public class GradeEntity
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        public int Score { get; set; }

    }
}
