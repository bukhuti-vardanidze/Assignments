namespace BonusManagementSystem_Api.Db.Entity
{
    public class EmpoyeeEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public double Salary { get; set; }
        public string Recomedator { get; set; }
        public DateTime StartDate { get; set; }
    }
}
