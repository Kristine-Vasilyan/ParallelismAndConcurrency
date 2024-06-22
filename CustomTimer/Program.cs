using CustomTimer;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        //example
        MyTimer myTimer = new MyTimer();
        myTimer.Start(1000, 5);
        Thread.Sleep(3000);
        myTimer.Stop();
        myTimer.Start(500, 5);
        Thread.Sleep(6000);
        //input 
        //Console.WriteLine("Enter timer interval in ms");
        //int interval = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter duration in seconds");
        //int duration = Convert.ToInt32(Console.ReadLine());
        //MyTimer myTimer = new MyTimer();
        //myTimer.Start(interval, duration);
        //Thread.Sleep(duration * 1000 + 500);

    }
}