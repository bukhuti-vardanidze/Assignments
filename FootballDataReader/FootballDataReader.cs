using FootballDataReader.Models;

namespace FootballDataReader;

public class FootballDataReader
{
    public List<Game> Read(string filePath)
    {
        var lines = ReadLines(filePath);
        var games = ConvertToGamesList(lines);
        return games;
    }

    private string[] ReadLines(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

    private List<Game> ConvertToGamesList(string[] lines)
    {
        var games = new List<Game>();
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            var game = ConvertToGame(line);
            if (game != null)
            {
                games.Add(game);
            }
        }
        return games;
    }

    private Game? ConvertToGame(string line)
    {
        var lineParts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

        try
        {
            var game = new Game();
            game.Date = DateTime.ParseExact(lineParts[0], "yyyy-MM-dd", null);
            game.HomeTeam = new Team { Name = lineParts[1] };
            game.AwayTeam = new Team { Name = lineParts[2] };

            game.Tournament = lineParts[5];
            game.City = lineParts[6];
            game.Country = lineParts[7];
            game.Neutral = bool.Parse(lineParts[8]);

            if (int.TryParse(lineParts[3], out var homeScore))
            {
                game.HomeScore = homeScore;
            }
            if (int.TryParse(lineParts[4], out var awayScore))
            {
                game.AwayScore = awayScore;
            }

            return game;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
