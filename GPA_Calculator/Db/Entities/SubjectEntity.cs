using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Db.Entities
{
    public class SubjectEntity
    {

        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        

    }
}
