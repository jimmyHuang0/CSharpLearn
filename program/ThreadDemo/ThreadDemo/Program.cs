using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTest test = new ThreadTest();
           // test.test();
           // test.test1();
            test.test2();
            Console.ReadLine();
        }



    }
}
