namespace ExtensionMethods
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("             string Extension Methods ");

            //is number
            string value = "abc";
            bool isnumeric = value.IsNumber();
            Console.WriteLine($" {value} is number ? : {isnumeric} ");
            value = "20";
            isnumeric = value.IsNumber();
            Console.WriteLine($" {value} is number ? : {isnumeric} ");


            //is date 
            string dateChecker1 = "hello !";
            string dateChecker2 = "02.09.2022";

            bool isDate = dateChecker1.IsDate();
            Console.WriteLine($" is date ? : {isDate} ");
            isDate = dateChecker2.IsDate();
            Console.WriteLine($" is date ? : {isDate} ");

            //safe to file

            string path = @"D:\my_files.txt";
            string info = path.SaveToFile();
            Console.WriteLine(info);

            //to word




            // double Extesion Methods
            Console.WriteLine("             Double Extension Methods ");
            // result to percent
            double num1 = 0.5;
            double resultToPercent = num1.ToPercent();
            Console.WriteLine(resultToPercent);

            // resultRound
            double num2 = 36.7;
            double resultRound = num2.RoundDown();
            Console.WriteLine(resultRound);

            // resultTodecimal

            decimal num3 = 367;
            var resultTodecimal = num3.NumbToDecimal();
            Console.WriteLine(resultTodecimal);

            //is greater than
            int i = 10;
            bool result = i.IsGreaterThan(100);
            Console.WriteLine(result);


            //is less than
            int j = 10;
            bool result1 = j.IsLessThan(100);
            Console.WriteLine(result1);






            Console.WriteLine("             DateTime Extension Methods ");





            //Beginning of the month
            DateTime dateTime = new DateTime(2022, 11, 23);
            DateTime dateTimeResult = dateTime.BeginningOfTheMonth();
            Console.WriteLine(dateTimeResult);


            // end of month

            DateTime date = new DateTime(2022, 11, 23);
            DateTime dateResult = date.GetLastDayOfMonth();
            Console.WriteLine(dateResult);





        }
    }
}
