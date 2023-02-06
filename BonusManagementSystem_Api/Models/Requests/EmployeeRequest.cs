namespace BonusManagementSystem_Api.Models.Requests
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public double Salary { get; set; }
        public int RecomedatorId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
