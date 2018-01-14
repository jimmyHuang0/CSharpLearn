using System.Diagnostics;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.fun1();
            test.fun1();
            test.fun1();
            test.fun1();
            test.fun1();
            test.fun1();
            test.fun1();
            Console.ReadLine();

        }
    }

    class Test
    {
        public void fun1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 99999999; i++)
            {
                //go nothing
                //show('a');
            }

           
            stopwatch.Stop();
            System.Console.WriteLine("{0}",stopwatch.ElapsedMilliseconds);
        }


        void show<T>(T par)
        {
            //do nothing
        }
    }
}
