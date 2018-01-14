using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.fun();
            test.funnn();


            //List<int> list = new List<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(i);
            //}

            //List<int> rList = list.findWhere(i=>i>5);


            List<int> rList = new List<int> { 1, 2, 6, 9, 56 }.findWhere(i => i > 5);
            foreach (var item in rList)
            {
                Console.WriteLine(item);
            }


            var v1 = from a in new List<int> { 1, 2, 6, 9, 56 }
                     where a > 5
                     select a;


            var v= test.yeildFun();
            Console.WriteLine("********* 开始 *********");
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }




            Console.WriteLine("********* 结束 *********");


            Console.ReadLine();

        }
    }
}
