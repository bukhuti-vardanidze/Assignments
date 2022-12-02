
Thread newthread = Thread.CurrentThread;
newthread.Name = "threading begin";

Thread thread1 = new(() => CountUp("Count Upp"));
Thread thread2= new(() => CountDown("Count Down"));

thread1.Start();
thread2.Start();






Console.WriteLine(newthread.Name);

static void CountUp(string TimerName)
{
	for (int i = 1; i <=10; i++)
	{

		Console.WriteLine($"{TimerName} {i}");
		Thread.Sleep(1000);
	}
	Console.WriteLine($"{TimerName} Done");
}

static void CountDown(string TimerName)
{
    for (int j = 10; j >= 1; j--)
    {

        Console.WriteLine($"{TimerName} {j}");
        Thread.Sleep(1000);
    }
    Console.WriteLine($"{TimerName} Done");
}