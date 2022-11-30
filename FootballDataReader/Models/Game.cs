namespace FootballDataReader.Models;

public class Game
{
    public DateTime Date { get; set; }
    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }
    public string Tournament { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public bool Neutral { get; set; }
}
