using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatePredicateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List < student > stuList= new List<student>
            {
                new student(){name="jimmy",ID=1},
                new student(){name="fare",ID=2},
                new student(){name="hjm",ID=3},
            };


            ///(a) => { return a.ID>= 2; } 是一个lambda表达式
            ///List的FindAll方式需要的是一个Predicate的方法
            ///Predicate是一个返回bool类型的委托：
            ///原型定义：
            ///     public delegate bool Predicate<T>(T arg);

            List<student> subList = stuList.FindAll((a) => { return a.ID>= 2; });
            foreach (var v in subList)
            {
                Console.WriteLine("{0} : {1}",v.name,v.ID);
            }




            Console.ReadLine();
        }
    }


    class student
    {
        public string name { get; set; }
        public int ID { get; set; }
    }
}
