using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateActionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Action是一种不带返回值的委托
            ///定义如下：
            ///     public delegate void Action<T1,T2,...Tn>(T1 arg1,T2 arg2,...,Tn argn);
            Action<string> act = (a) => Console.WriteLine("hello {0}", a);
            act("ming");


            ///Func是一种预定义的带参数返回的泛型委托，最后一个是返回值TResult
            ///定义如下：
            ///     public delegate TResult Func<T1,T2,...Tn,TResult>(T1 arg1,T2 arg2,...,Tn argn);
            Func<string, int> fun = (a) =>
               {
                   Console.WriteLine("hello {0}", a);
                   return 1;
               };
            Console.WriteLine(fun("jimmy"));


            

            Console.ReadLine();

        }
    }
}
