using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitAsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.fun();
        }
    }


    class Test
    {
        static public void fun()
        {
            Console.WriteLine($"主线程开始: {Thread.CurrentThread.ManagedThreadId}");
            Task task = Task.Run(() =>
              {
                  Console.WriteLine($"子线程开始{Thread.CurrentThread.ManagedThreadId}");
                  Thread.Sleep(1000);
                  Console.WriteLine($"子线程结束{Thread.CurrentThread.ManagedThreadId}");
              });
            Console.WriteLine($"主线程结束{Thread.CurrentThread.ManagedThreadId}");


            Console.Read();
        }



    }


}
