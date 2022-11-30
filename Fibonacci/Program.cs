namespace Fibonacci
{
    class Program
    {
        public static int FibonacciNumber(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return n;
            }
            else
            {
                return (FibonacciNumber(n - 1) + FibonacciNumber(n - 2));
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter the  number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            number = number - 1;
           

            Console.Write(FibonacciNumber(number));
            Console.ReadLine();
        }
    }
}