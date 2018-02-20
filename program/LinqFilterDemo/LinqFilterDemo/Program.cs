using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFilterDemo
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ///这是原始列表
            Dictionary<int, string> dicA = new Dictionary<int, string>() { { 1, "a" }, { 2, "b" }, { 3, "b" }, { 4, "c" } };
            ///这是筛选列表
            List<string> FilterList = new List<string>() { "a", "b" };
            Console.WriteLine("-------------dicA--------------");
            foreach (var item in dicA)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------FilterList--------------");
            foreach (var item in FilterList)
            {
                Console.WriteLine(item);
            }

            {
                ///筛选
                var list = from item in dicA
                           where FilterList.Contains(item.Value)
                           select item;
                Console.WriteLine("-------------筛选--------------");
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            {
                ///方式一：分组，选择新建结果
                var list1 = from item in dicA
                            group item by item.Value into l
                            select new { name = l.Key, cnt = l.Count() };
                Console.WriteLine("-------------方式一：分组，选择新建结果--------------");
                foreach (var item in list1)
                {
                    Console.WriteLine(item);
                }
            }
            {
                ///方式二：分组，选择新建结果
                var list2 = dicA.GroupBy(a => a.Value).
                    Select((l)=> (new{ name = l.Key, cnt = l.Count()}));
                Console.WriteLine("-------------方式二：分组，选择新建结果--------------");
                foreach (var item in list2)
                {
                    Console.WriteLine(item);
                }
            }
            {
                ///方式一：分组，选择总体结果
                var list2 = from item in dicA
                            group item by item.Value into l
                            select l;
                Console.WriteLine("--------------方式一：分组，选择总体结果-------------");
                foreach (var item in list2)
                {
                    Console.WriteLine(item.Key);//打印group的名字
                    foreach (var item1 in item)//打印group的子列表
                    {
                        Console.WriteLine(item1);
                    }
                }
            }
            {
                ///方式二：分组，选择总体结果
                var list2 = dicA.GroupBy(a => a.Value);
                Console.WriteLine("-------------方式二：分组，选择总体结果--------------");
                foreach (var item in list2)
                {
                    Console.WriteLine(item.Key);//打印group的名字
                    foreach (var item1 in item)//打印group的子列表
                    {
                        Console.WriteLine(item1);
                    }
                }
            }            
            Console.ReadLine();

        }
    }
}
