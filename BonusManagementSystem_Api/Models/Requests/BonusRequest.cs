namespace BonusManagementSystem_Api.Models.Requests
{
    public class BonusRequest
    {
        public int BonusId { get; set; }
        public int RecomendaorId { get;set; }
        public double BonusNewAmount { get; set; }

    }
}
