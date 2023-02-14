namespace BonusManagementSystem_Api.Models.Requests
{
    public class BonusRequest
    {
        public int EmployeeId { get; set; }
        public int recomendtorId { get; set; }
        public double BonusQuantity { get; set; }

    }
}
