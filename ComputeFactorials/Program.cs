
internal class Program
{
    private static void Main(string[] args)
    {
        //Input
        //Console.WriteLine("Number of elements: ");
        //int size = Convert.ToInt32(Console.ReadLine());
        //int[] array = new int[size];
        //for (int i = 0; i < size; i++)
        //{
        //    Console.WriteLine($"Element {i} :");
        //    array[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //Parallel.ForEach(array, Factorial);
        //Example
        int[] arr = { 5, 10, 15 };
        Parallel.ForEach(arr, Factorial);
    }
    static void Factorial(int n)
    { 
        using ThreadLocal<int> factorial = new ThreadLocal<int>(() => 1);
        if (n < 0) 
        { 
            factorial.Value = -1;
        }
        else for (int i = 1; i <= n; i++)
        {
            factorial.Value *= i;
        }
        Console.WriteLine($"{n}! = {factorial.Value}");
    }
}