
namespace BinarySearch
{
    class Program
    {


        public static void Main(String[] args)
        {

            int[] arr = new int[7] { 21, 15, 45, 40, 6, 25, 73 };
            Array.Sort(arr);
            Console.Write("The elements of Sorted Array: ");
            display(arr);
            Console.WriteLine("\nIndex of 45  is: " + Array.BinarySearch(arr, 45));
        }


        static void display(int[] arr1)
        {
            foreach (int i in arr1)
                Console.Write(i + " ");
        }
    }

}