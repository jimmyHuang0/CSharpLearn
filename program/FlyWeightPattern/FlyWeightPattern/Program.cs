using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlyWeightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"id={Thread.CurrentThread.ManagedThreadId}");

            Test test = new Test();

            Console.WriteLine("******* 异步调用 ********");
            new Action(test.showA).BeginInvoke(null, null);
            new Action(test.showB).BeginInvoke(null, null);

            Console.WriteLine("******* 同步调用 ********");
            test.showA();
            test.showB();

 
            Console.ReadLine();
        }




    }
}
