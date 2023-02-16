namespace BonusManagementSystem_Api.Db.Entity
{
    public class BonusEntity
    {
        public int Id { get; set; }
        public int  employeeId { get; set; }
        public double BonusQuantity { get; set; }
        public DateTime BonusIssueTime { get; set; }
       public EmployeeEntity EmployeeEntity { get; set; }
    }
}
