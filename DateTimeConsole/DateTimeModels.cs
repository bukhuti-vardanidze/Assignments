using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeConsole
{
   
       public class DateTimeModels
        {

            //current date
            public void CurrentDateTime()
            {
                Console.Write("Current Date is : ");
                DateTime date = DateTime.Now;
                string createdDate = $"{date:yyyy-MM-dd h:mm}";
                Console.WriteLine(createdDate);
                Console.WriteLine(" ");
            }


            //current london time
            private static TimeZoneInfo _tokyoStandardTime = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            public void CurrentLondonDate()
            {

                DateTime dateTimeTokyo = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _tokyoStandardTime);
                // DateTime dateTime = DateTime.Now;
                Console.WriteLine(dateTimeTokyo);
            }


            //DaysBetween 2022-01-01 --  2023-01-31

            public void DaysBetween()
            {
                Console.Write("Difference Days in  2022-01-01 --  2023-01-31  is : ");

                DateTime start = new DateTime(2022, 01, 01);
                DateTime end = new DateTime(2023, 01, 31);

                TimeSpan difference = end - start;

                Console.WriteLine(difference.Days);

                Console.WriteLine(" ");
            }


            // is leap year
            public void LeapYear()
            {
                Console.Write("Enter Year : ");
                int yearInput = Convert.ToInt32(Console.ReadLine());
                bool inputYear = DateTime.IsLeapYear(yearInput);
                if (inputYear)
                {
                    Console.Write($"{yearInput} is Leap Year");
                }
                else
                {
                    Console.Write($"{yearInput} Is Not Leap Year");
                }

                Console.WriteLine(" ");
            }


            //First Day Of Previous Month

            public void FirstDayOfPreviousMonth()
            {
                Console.WriteLine(" ");
                var yr = DateTime.Today.Year;
                var mth = DateTime.Today.Month;
                var firstDay = new DateTime(yr, mth, 1).AddMonths(-1);

                Console.Write("First day Previous Month: {0}", firstDay);
                Console.WriteLine(" ");
            }

            //last Day Of Previous Month
            public void LastDayOfPreviousMonth()
            {
                Console.WriteLine(" ");
                var yr = DateTime.Today.Year;
                var mth = DateTime.Today.Month;
                var lastDay = new DateTime(yr, mth, 1).AddDays(-1);

                Console.Write("Last day Previous Month: {0}", lastDay);
                Console.WriteLine(" ");
            }


            //Current Week Day
            public void CurrentWeekDay()
            {

                Console.WriteLine(" ");
                int wday;

                //input wday number
                Console.Write("Enter weekday number (1-7): ");
                wday = Convert.ToInt32(Console.ReadLine());


                switch (wday)
                {

                    case 1:
                        Console.WriteLine("It's MONDAY");
                        break;
                    case 2:
                        Console.WriteLine("It's TUESDAY");
                        break;
                    case 3:
                        Console.WriteLine("It's WEDNESDAY");
                        break;
                    case 4:
                        Console.WriteLine("It's THURSDAY");
                        break;
                    case 5:
                        Console.WriteLine("It's FRIDAY");
                        break;
                    case 6:
                        Console.WriteLine("It's SATURDAY");
                        break;
                    case 7:
                        Console.WriteLine("It's SUNDAY");
                        break;

                    //if no case value is matched
                    default:
                        Console.WriteLine("It's wrong input...");
                        break;
                }


                Console.WriteLine(" ");
            }

        }
    
}
