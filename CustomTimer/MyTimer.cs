using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTimer
{
    internal class MyTimer
    {
        private Thread TimerThread;
        private int interval;
        private int iterationCount;
        private int remainder;
        private bool isRunning;
        private static readonly object locker = new();
        public void Start(int interval, int duration)
        { 
            this.interval = interval;
            iterationCount = duration * 1000 / interval;
            remainder = duration * 1000 % interval;
            isRunning = true;
            TimerThread = new Thread(new ThreadStart(Running));
            TimerThread.Start();
        }
        public void Stop() 
        {
            lock (locker) 
            {
                isRunning = false;
            }
            TimerThread.Join();
            Console.WriteLine("Timer stopped");
        }
        private void Running() 
        {
            bool isStopped = false;
            for (int i = 1; i <= iterationCount; i++)
            {
                lock(locker) 
                {
                    isStopped = !isRunning;
                }
                if (isStopped)
                {
                    break;
                }
                Thread.Sleep(interval);
                Callback(i);
            }
            if (!isStopped)
            {
                Thread.Sleep(remainder);
                Console.WriteLine("Timer completed");
            }
        }
        private void Callback(int iteration)
        {
            Console.WriteLine($"Timer callback at {iteration} iteration");
        }

    }
}
