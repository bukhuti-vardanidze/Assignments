using System.ComponentModel.DataAnnotations;

namespace BonusManagementSystem_Api.Db.Entity
{
    public class EmployeeEntity
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public double Salary { get; set; }
        public int RecomedatorId { get; set; }
        public DateTime StartDate { get; set; }

        public List<BonusEntity> BonusEntity { get; set; }
    }
}
