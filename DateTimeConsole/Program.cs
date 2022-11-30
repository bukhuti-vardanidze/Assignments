

namespace DateTimeConsole
{
    class Program
    {
        static void Main()
        {
            DateTimeModels dateModel = new DateTimeModels();
            dateModel.CurrentDateTime();
            dateModel.DaysBetween();
            dateModel.LeapYear();
            dateModel.FirstDayOfPreviousMonth();
            dateModel.LastDayOfPreviousMonth();
            dateModel.CurrentWeekDay();

            Console.Write("Current Tokyo Date is : ");
            dateModel.CurrentLondonDate();
            Console.WriteLine(" ");

        }
    }
}
