using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            test t = new test();

            test.fun();
            t.fun1();


            Console.ReadLine();
           
        }
    }

    class test
    {
        public static void fun()
        {

            for (int i = 0; i < 1000; i++)
            {
                int j = i;
                Task task = new Task(() => 
                { 
                    Debug.WriteLine($"{j==add(j)} {j}={add(j)}");
                });
                task.Start();
            }   
        }

        static int add(int a)
        {
            return a;
        }


        public void fun1()
        {

            for (int i = 0; i < 1000; i++)
            {
                int j = i;
                Task task = new Task(() =>
                {
                    Debug.WriteLine($"{j == add(j)} {j}={add(j)}");
                });
                task.Start();
            }
        }

        int add1(int a)
        {
            return a;
        }
    }
}
