using BonusManagementSystem_Api.Db.Entity;

namespace BonusManagementSystem_Api.Models
{
    public class CalculateBonus
    {
        public int countBonuses { get; set; }
        public double sumBonuses { get; set;}
        public BonusEntity bonusEntity { get; set; }
    }
}
