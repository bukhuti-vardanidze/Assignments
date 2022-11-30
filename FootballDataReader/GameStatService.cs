using FootballDataReader.Models;

namespace FootballDataReader;

public class GameStatService
{
    private Dictionary<string, Team> _teams = new Dictionary<string, Team>();

    public void Calculate(List<Game> games)
    {

        Console.WriteLine(" ");
        CalculateHomeScores(games);
        Console.WriteLine(" ");
        CalculateAwayScores(games);
        Console.WriteLine(" ");
        CalculateTop10Scores(games);
        Console.WriteLine(" ");
        CalculateCounts(games);
        Console.WriteLine(" ");
        CalculateLast10Scores(games);
        Console.WriteLine(" ");
    }

    private void CalculateAwayScores(List<Game> games)
    {
        foreach (var awayScore in games)
        {
            // Away team
            if (_teams.ContainsKey(awayScore.AwayTeam.Name))
            {
                var AwayScores = _teams[awayScore.AwayTeam.Name];
                AwayScores.TotalGoals += awayScore.AwayScore ?? 0;
            }
            else
            {
                _teams.Add(awayScore.AwayTeam.Name, new Team
                {
                    Name = awayScore.AwayTeam.Name,
                    TotalGoals = awayScore.AwayScore ?? 0
                });
            }

        }

        var awayScores = _teams
            .OrderByDescending(g => g.Value.TotalGoals)
            .Take(Range.All);
        Console.WriteLine("Calculate Away Scores :");
        foreach (var AwayScores in awayScores)
        {

            Console.WriteLine($" {AwayScores.Key} - {AwayScores.Value.TotalGoals} ");
        }
    }

    private void CalculateHomeScores(List<Game> games)
    {

        foreach (var homeScore in games)
        {
            // Home team
            if (_teams.ContainsKey(homeScore.HomeTeam.Name))
            {
                var HomeScore = _teams[homeScore.HomeTeam.Name];
                HomeScore.TotalGoals += homeScore.HomeScore ?? 0;
            }
            else
            {
                _teams.Add(homeScore.HomeTeam.Name, new Team
                {
                    Name = homeScore.HomeTeam.Name,
                    TotalGoals = homeScore.HomeScore ?? 0
                });
            }



        }

        var homeScores = _teams
            .OrderByDescending(g => g.Value.TotalGoals)
            .Take(Range.All);
        Console.WriteLine("Calculate Home  Scores :");
        foreach (var HomeScore in homeScores)
        {

            Console.WriteLine($" {HomeScore.Key} - {HomeScore.Value.TotalGoals} ");
        }


    }

    private void CalculateLast10Scores(List<Game> games)
    {


        foreach (var game1 in games)
        {
            // Home team
            if (_teams.ContainsKey(game1.HomeTeam.Name))
            {
                var last10Team = _teams[game1.HomeTeam.Name];
                last10Team.TotalGoals += game1.HomeScore ?? 0;
            }
            else
            {
                _teams.Add(game1.HomeTeam.Name, new Team
                {
                    Name = game1.HomeTeam.Name,
                    TotalGoals = game1.HomeScore ?? 0
                });
            }

            // Away team
            if (_teams.ContainsKey(game1.AwayTeam.Name))
            {
                var team = _teams[game1.AwayTeam.Name];
                team.TotalGoals += game1.AwayScore ?? 0;
            }
            else
            {
                _teams.Add(game1.AwayTeam.Name, new Team
                {
                    Name = game1.AwayTeam.Name,
                    TotalGoals = game1.AwayScore ?? 0
                });
            }

        }

        var last10Scores = _teams
            .OrderByDescending(g => g.Value.TotalGoals)
            .TakeLast(10);
        Console.WriteLine("Calculate last 10 Scores :");
        foreach (var last10Team in last10Scores)
        {

            Console.WriteLine($" {last10Team.Key} - {last10Team.Value.TotalGoals} ");
        }

    }

    private void CalculateTop10Scores(List<Game> games)
    {
        foreach (var game in games)
        {
            // Home team
            if (_teams.ContainsKey(game.HomeTeam.Name))
            {
                var team = _teams[game.HomeTeam.Name];
                team.TotalGoals += game.HomeScore ?? 0;
            }
            else
            {
                _teams.Add(game.HomeTeam.Name, new Team
                {
                    Name = game.HomeTeam.Name,
                    TotalGoals = game.HomeScore ?? 0
                });
            }

            // Away team
            if (_teams.ContainsKey(game.AwayTeam.Name))
            {
                var team = _teams[game.AwayTeam.Name];
                team.TotalGoals += game.AwayScore ?? 0;
            }
            else
            {
                _teams.Add(game.AwayTeam.Name, new Team
                {
                    Name = game.AwayTeam.Name,
                    TotalGoals = game.AwayScore ?? 0
                });
            }

        }

        var top10Scores = _teams
            .OrderByDescending(g => g.Value.TotalGoals)
            .Take(10);

        Console.WriteLine("Calculate Top 10 Scores :");
        foreach (var team in top10Scores)
        {

            Console.WriteLine($"{team.Key} - {team.Value.TotalGoals}");
        }
    }

    private static void CalculateCounts(List<Game> games)
    {
        var totalFinishedGames = games.Count(g => g.HomeScore.HasValue && g.AwayScore.HasValue);
        var totalPlannedGames = games.Count - totalFinishedGames;
        Console.WriteLine($"Total finished games: {totalFinishedGames}");
        Console.WriteLine($"Total planned games: {totalPlannedGames}");
    }


}