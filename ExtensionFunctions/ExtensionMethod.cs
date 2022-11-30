namespace ExtensionMethods
{
    public static class ExtensionMethod
    {

        //string Extension Method



        public static bool IsNumber(this string value)
        {
            return long.TryParse(value, out _);
        }




        public static bool IsDate(this string value2)
        {
            if (!string.IsNullOrEmpty(value2))
            {
                return (DateTime.TryParse(value2, out _));
            }
            else
            {
                return false;
            }
        }




        public static string SaveToFile(this string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write("  hello but! ");
                sw.Write("  C# Practice ");
                sw.Write("   hi ");
                sw.Write("   SHA256 ");
            }

            Console.Write("  texts will be written to the specified file : ");
            return path;
        }





        //double Extension methods
        public static double ToPercent(this double num1)
        {
            Console.Write($" The percentage value of {num1} will be : ");
            return (num1 * 100);
        }



        public static double RoundDown(this double num2)
        {
            Console.Write($" The rounded value of {num2} will be : ");
            return Math.Floor(num2);
        }

        public static decimal NumbToDecimal(this decimal num3)
        {
            Console.Write($" {num3} to Decimal will be : ");
            decimal numb3 = Convert.ToDecimal(num3);
            return numb3;


        }

        public static bool IsGreaterThan(this int i, int value)
        {
            Console.Write(" Answer is (isGreaterThan) : ");
            return i > value;

        }

        public static bool IsLessThan(this int j, int value)
        {
            Console.Write(" Answer is (IsLessThan) : ");
            return j < value;

        }


        //  datetime methods






        public static DateTime BeginningOfTheMonth(this DateTime dateTime)
        {
            Console.Write(" Beginning of the moth is :  ");
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }


        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            Console.Write(" Last Day Of Month is :  ");
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        }


    }

}
