using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asyncAwaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.fun();
            Console.ReadLine();

        }
    }

    class Test
    {
        //结果：
        //  开始执行主函数
        //  funT执行主函数
        //  主函数执行点其他的
        //  ...
        //  ...
        //  ...
        //  funT结束主函数
        //  await
        //  结束执行主函数

        public void fun()
        {
            Console.WriteLine("开始执行主函数");         //-->1

            var v = funT();                              
            Thread.Sleep(100);                           
            Console.WriteLine("主函数执行点其他的");     //-->3

            Console.WriteLine(v.Result);                 //-->4

            Console.WriteLine("结束执行主函数");         //-->5
        }

        async Task<string> funT()
        {
            Console.WriteLine("funT执行主函数");         //-->2

            string v = await Task.Run<string >(() =>     //-->3
            {                                            //
                Console.WriteLine("...");                //
                Thread.Sleep(1000);                      //
                Console.WriteLine("...");                //
                Thread.Sleep(1000);                      //
                Console.WriteLine("...");                //
                Thread.Sleep(1000);                      //
                Console.WriteLine("...");                //
                return "await";                          //
            });                                          //
                                                         //
            Console.WriteLine("funT结束主函数");         //
            return v;

        }
    }
}
