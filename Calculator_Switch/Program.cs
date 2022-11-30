namespace CalculatorSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter First number : ");
            double number1 = double.Parse(Console.ReadLine());
            Console.Write("Enter Second number : ");
            double number2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Choose One Of This : [+] [-] [*] [/] [%] ");
            string Operation = Console.ReadLine();

            switch (Operation)
            {
                case "+":
                    Console.WriteLine($"{number1} + {number2} = {number1 + number2} ");
                    break;
                case "-":
                    Console.WriteLine($"{number1}  - {number2} = {number1 - number2} ");
                    break;
                case "/":
                    Console.WriteLine($"{number1} / {number2} = {number1 / number2} ");
                    break;
                case "*":
                    Console.WriteLine($"{number1} * {number2} = {number1 * number2} ");
                    break;
                case "%":
                    Console.WriteLine($"{number1} % {number2} = {number1 % number2} ");
                    break;
                default:
                    Console.WriteLine("choose right operation!");
                    break;


            }
            Console.ReadLine();
        }
    }
}
