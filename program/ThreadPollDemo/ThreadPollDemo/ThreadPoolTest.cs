using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPollDemo
{
    class ThreadPoolTest
    {
        public static void test()
        {
            int i;
            int j;
            for (int k = 0; k < 1000; k++)
            {
                ThreadPool.QueueUserWorkItem(t =>
                {
                    ThreadPool.GetAvailableThreads(out i, out j);
                    Console.WriteLine($"threadID={Thread.CurrentThread.ManagedThreadId} {i} {j}");
                });
            }

        }




    }
}
