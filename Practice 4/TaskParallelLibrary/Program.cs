using System;
using System.Threading;
using System.Threading.Tasks;



namespace TaskParallelLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task task1 = new(() => Console.WriteLine("start task 1"));
            //task1.Start();

            //Task task2 = Task.Factory.StartNew(() => Console.WriteLine("start task 2"));

            //Task task3 = Task.Run(() => Console.WriteLine("start task 3"));


            //task1.Wait();
            //task2.Wait();
            //task3.Wait();

            Console.WriteLine("Main starts");
            Task task = new( () =>
             {
                 Console.WriteLine("start");
                 Thread.Sleep(1000);
                 Console.WriteLine("end");

             });


            task.RunSynchronously();
            task.Wait();

            Console.WriteLine("Main Done");


        }



    }
}