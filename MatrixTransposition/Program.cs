using System;
using System.Threading;

internal class Program
{
    static int[,] Matrix;
    static int[,] Transpos;
    static int MatrixRow;
    static int MatrixColumn;
    static Mutex mutex;
    private static void Main(string[] args)
    {
        //Input
        //Console.WriteLine("Enter Matrix size");
        //Console.WriteLine("Row: ");
        //MatrixRow = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Row: ");
        //MatrixColumn = Convert.ToInt32(Console.ReadLine());
        //Matrix = new int[MatrixRow, MatrixColumn];
        //for (int i = 0; i < MatrixRow; i++)
        //{
        //    for (int j = 0; j < MatrixColumn; j++)
        //    {
        //        Console.WriteLine($"Matrix[{i}, {j}]");
        //        Matrix[i, j] = Convert.ToInt32(Console.ReadLine());
        //    }
        //}
        //Example
        Matrix = new int[,] { { 1, 2, 3 },
                              { 4, 5, 6 } };
        MatrixRow = Matrix.GetLength(0);
        MatrixColumn = Matrix.GetLength(1);
        // Transpos
        Transpos = new int[MatrixColumn, MatrixRow];
        mutex = new Mutex();
        for (int i = 0; i < MatrixRow; i++) 
        {
            int row = i;
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object s) { RowToColumn(row); }));
        }
        Thread.Sleep(1000);
        for (int i = 0; i < MatrixColumn; i++)
        {
            for (int j = 0; j < MatrixRow; j++)
            {
                Console.Write(Transpos[i, j] + " ");
            }
            Console.WriteLine();
        }

    }
    static void RowToColumn(object x)
    {
        int row = (int)x;
        for (int i = 0; i < MatrixColumn; i++)
        {
            mutex.WaitOne();
            Transpos[i, row] = Matrix[row, i];
            mutex.ReleaseMutex();
        }
    }
}