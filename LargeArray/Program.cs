using System.Diagnostics.CodeAnalysis;
using System.Threading;

internal class Program
{
    static int[] Array;
    private static void Main(string[] args)
    {
        int size;
        int step;
        //input array
        //Console.WriteLine("Input Array size: ");
        //size = Convert.ToInt32(Console.ReadLine());
        //Array = new int[size];
        //for (int curr = 0; curr < size; curr++)
        //{
        //    Console.WriteLine($"Element {curr}: ");
        //    Array[curr] = Convert.ToInt32(Console.ReadLine());
        //}
        //Console.WriteLine("Step: ");
        //step = Convert.ToInt32(Console.ReadLine());
        //Example
        Array = Enumerable.Range(1, 1000000).ToArray();
        size = Array.Length;
        step = 101;
        //calculate
        int i = 0;
        List<Task<long>> tasks = new List<Task<long>>();
        while (i + step < size)
        {
            int start = i;
            int end = i + step;
            tasks.Add(Task.Factory.StartNew(() => AddPart(start, end)));
            i += step;
        }
        tasks.Add(Task.Factory.StartNew(() => AddPart(i, size)));
        Task.WaitAll(tasks.ToArray());
        long sum = tasks.Sum(x => x.Result);
        Console.WriteLine($"Sum is: {sum}");
    }
    static long AddPart(int start, int end)
    {
        long sum = 0;
        for (int i = start; i < end; i++) 
        { 
            sum += Array[i];
        }
        return sum;
    }
}