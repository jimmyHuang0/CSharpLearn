using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TON ton = new TON();
            bool IN = true;
            bool q = false;
            long et = 0;
            // ton.Update(true, 1000,ref q, ref et);

            //List<long> lET = new List<long>();
            long time=0;

            Console.WriteLine(DateTime.MaxValue.Ticks);
            Console.WriteLine(DateTime.MinValue.Ticks);


            //for (int i = 0; i < 10; i++)
            //{
            time = (DateTime.Now.ToUniversalTime().Ticks);
                while (!q)
                {
                    ton.Update(IN, 1000, ref q, ref et);
                    Console.WriteLine($"in={IN} et={et} q={q} ticks={DateTime.Now.Ticks}");
                    Thread.Sleep(100);
                }
                time = (DateTime.Now.ToUniversalTime().Ticks) - time;
                ton.Update(false, 1000, ref q, ref et);
                //Console.WriteLine(time);
           // }






            Console.ReadLine();
        }
    }
}





     
     
     */
