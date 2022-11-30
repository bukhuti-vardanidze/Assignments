namespace FootballDataReader
{
    class Program
    {
        static void Main()
        {
            var filePath = @"C:\Users\varda\Desktop\CredoBankAssignments\FootballDataReader\File\football_results.csv";
            var reader = new FootballDataReader();
            var games = reader.Read(filePath);

            var statService = new GameStatService();
            statService.Calculate(games);
        }
    }
}
