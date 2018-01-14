using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            genericClass<int> gc = new genericClass<int>();
            gc.p = 1;
            Console.WriteLine(gc.p);
            Console.ReadLine();
        }
    }
}
